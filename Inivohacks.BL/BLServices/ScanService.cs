using Inivohacks.BL.DTOs.Models;
using Inivohacks.DAL.Models;
using Inivohacks.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Inivohacks.BL.BLServices
{
    public class ScanService : IScanService
    {
        private readonly ITrackingCodeRepositoryForScan _iTrackingCodeRepositoryForScan;
        private readonly IScanRepository _iScanRepository;

        public ScanService(ITrackingCodeRepositoryForScan trackingCodeRepositoryForScan, IScanRepository scanRepository)
        {
            _iTrackingCodeRepositoryForScan = trackingCodeRepositoryForScan;
            _iScanRepository = scanRepository;
        }
        public async Task<TrackingCode> Add(TrackingCode tr)
        {
            var obj = await _iTrackingCodeRepositoryForScan.AddAsync(tr);
            return obj;
        }
        public async Task<ScannedItemInfomationModel?> GetItemInformation(Guid guId, int? CertificateId, int? UserId, string? Latitude, string? Longitude, string? Location)
        {
            CertificateId ??= 1;
            UserId ??= 1;
            Latitude ??= "";
            Location ??= "";
            Longitude ??= "";

            var obj = await _iTrackingCodeRepositoryForScan.Search(o => o.TrackingCodeID == guId).Include(o => o.Product).Include(o => o.Product.Manufacturer).FirstOrDefaultAsync();
            if (obj == null)
            {
                return null;
            }

            await _iScanRepository.AddAsync(new Scan()
            {
                ScanGuid = guId,
                TrackingCodeID = guId,
                InteractionType = "Scan",
                InteractionDescription = "",
                CertificateID = (int)CertificateId,
                UserID = (int)UserId,
                Latitude=Latitude,
                Longitude=Longitude,
                LocationName= Location,
            });
            var listOfScansForTrackingCode = await _iScanRepository.Search(o => o.ScanGuid == guId ).OrderByDescending(o=>o.TimeStamp).ToListAsync();

            string scanType = "Active";
            string lastAvailableLocation = "Not Given";
            for (var i = 0; i < listOfScansForTrackingCode.Count; i++)
            {
                var loopObj = listOfScansForTrackingCode[i];

                if (loopObj.InteractionType == StaticVariables.TransferAccepted && lastAvailableLocation== "Not Given")
                {
                    lastAvailableLocation = loopObj.LocationName;
                }

                if (scanType== "Active" && (loopObj.InteractionType == StaticVariables.Rebranded || loopObj.InteractionType == StaticVariables.Recall))
                {
                    scanType = loopObj.InteractionType +". Not safe to use";
                }
            }

            if (lastAvailableLocation == "Not Given")
            {
                lastAvailableLocation = obj.Product.Manufacturer.Address;
            }
            Guid trackerCode = guId;
            bool exitLoop = false;
            List<string> rebrandHistory= new List<string>();
            do {

                var parentObject = await _iScanRepository.Search(o=>o.TrackingCodeID == trackerCode && o.InteractionType==StaticVariables.Rebranded).SingleOrDefaultAsync();
                if (parentObject != null)
                {
                    trackerCode = parentObject.ScanGuid;
                    var recallScan = await _iScanRepository.Search(o => o.ScanGuid == trackerCode && o.InteractionType==StaticVariables.Recall).FirstOrDefaultAsync();

                    if (recallScan != null)
                    {
                        var trackerObj = await _iTrackingCodeRepositoryForScan.Search(o => o.TrackingCodeID == guId).Include(o=>o.Product).FirstOrDefaultAsync();

                        scanType = $"Item has been recalled as {trackerObj.Product.Name}. Product not safe to use.";

                       
                    }
                }
                else {
                    exitLoop = true;
                }

            } while (!exitLoop);



            return new ScannedItemInfomationModel()
            {
                TrackingCodeID = guId,
                ProductName = obj.Product.Name,
                Dosage = obj.Product.Dosage,
                ManufacturerAddress = obj.Product.Manufacturer.Address,
                ManufacturerName = obj.Product.Manufacturer.Name,
                RecallStatus = scanType,
                ExpiryDate=obj.ExpiredDate,
                ManufacturedDate=obj.ManufacturedDate,
                LastAvailablelocation=lastAvailableLocation

            };
        }

        public async Task<Guid> Rebrand(RebrandTrackerCodeDTO rebrandData)
        {

            var obj = await _iTrackingCodeRepositoryForScan.Search(o => o.TrackingCodeID == rebrandData.CurrentTrackingCodeID).FirstOrDefaultAsync();

            if (obj == null)
            {
                throw new Exception("The object to rebrand with given CurrentTrackingCodeID was not found");
            }
            var listOfScansForTrackingCode = await _iScanRepository.Search(o => o.ScanGuid == rebrandData.CurrentTrackingCodeID && o.InteractionType==StaticVariables.Rebranded).ToListAsync();

            if (listOfScansForTrackingCode.Count > 0)
            {
                throw new Exception("The CurrentTrackingCodeID you entered has already been rebranded ");

            }

            TrackingCode rebrandedTrackingCode = new()
            {
                ProductID = rebrandData.ProductId,
                Code=rebrandData.Code,
                BatchNumber=rebrandData.BatchNumber,
                ManufacturedDate= obj.ManufacturedDate,
                ExpiredDate=obj.ExpiredDate,
                
            };

            rebrandedTrackingCode=await _iTrackingCodeRepositoryForScan.AddAsync(rebrandedTrackingCode);

            await _iScanRepository.AddAsync(new Scan()
            {
                ScanGuid = rebrandData.CurrentTrackingCodeID,
                TrackingCodeID = rebrandedTrackingCode.TrackingCodeID,
                InteractionType = StaticVariables.Rebranded,
                InteractionDescription = "",
                CertificateID = rebrandData.CertificateId,
                LocationName = rebrandData.LocationName,
                Latitude    = rebrandData.Latitude,
                Longitude   = rebrandData.Longitude,
                UserID = rebrandData.UserId,
            });

          /*  await _iScanRepository.AddAsync(new Scan()
            {
                ScanGuid = rebrandedTrackingCode.TrackingCodeID,
                TrackingCodeID = rebrandedTrackingCode.TrackingCodeID,
                InteractionType = StaticVariables.Created,
                InteractionDescription = "",
                CertificateID = rebrandData.CertificateId,
                UserID = rebrandData.UserId,
                LocationName = rebrandData.LocationName,
                Latitude = rebrandData.Latitude,
                Longitude = rebrandData.Longitude,
            });*/


            return rebrandedTrackingCode.TrackingCodeID;
        }

        public async Task<string> Recall(RecallDTO model)
        {
            var obj = await _iTrackingCodeRepositoryForScan.Search(o => o.TrackingCodeID == model.TrackingCode).FirstOrDefaultAsync();

            if (obj == null)
            {
                throw new Exception("The object to rebrand with given guId was not found");
            }
            await _iScanRepository.AddAsync(new Scan()
            { 
                TrackingCodeID = model.TrackingCode,
                ScanGuid = model.TrackingCode,
                InteractionType = StaticVariables.Recall,
                InteractionDescription = $"Medicine was recalled on {DateTime.Now.ToString("dddd, dd MMMM yyyy")}",
                CertificateID = model.CertificateId,
                UserID = model.UserId,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                LocationName = model.LocationName
            });

           

            return StaticVariables.SuccessMessage;
        }

        public async Task<string> RequestTransfer(TransferBatchDTO transferBatchDTO)
        {

            var obj = await _iTrackingCodeRepositoryForScan.Search(o => o.TrackingCodeID == transferBatchDTO.TrackingCode).FirstOrDefaultAsync();

            if (obj == null)
            {
                throw new Exception("The object to transfer with given TrackingCode was not found");
            }

            var listOfScansForTrackingCode = await _iScanRepository.Search(o => o.ScanGuid == transferBatchDTO.TrackingCode).OrderByDescending(o => o.TimeStamp).ToListAsync();

            if (listOfScansForTrackingCode.Where(o => o.InteractionType == StaticVariables.Rebranded).ToList().Count > 0)
            {
                throw new Exception("The item cannot be transferred as it has been rebranded");
            }

            string transferType = "None";

            for (var i = 0; i < listOfScansForTrackingCode.Count; i++)
            {
                var loopObj = listOfScansForTrackingCode[i];
                if (loopObj.InteractionType == StaticVariables.TransferRequested || loopObj.InteractionType == StaticVariables.TransferAccepted)
                {
                    transferType = loopObj.InteractionType;
                    break;
                }
            }

            if (transferType == StaticVariables.TransferRequested)
            {
                throw new Exception("Transfer request already present");
            }

            await _iScanRepository.AddAsync(new Scan()
            {
                ScanGuid = transferBatchDTO.TrackingCode,
                TrackingCodeID= transferBatchDTO.TrackingCode,
                InteractionType = StaticVariables.TransferRequested,
                InteractionDescription = "",
                CertificateID = transferBatchDTO.CertificateId,
                UserID = transferBatchDTO.UserId,
                Latitude= transferBatchDTO.Latitude,
                Longitude= transferBatchDTO.Longitude,
                LocationName = transferBatchDTO.LocationName
            });

            return StaticVariables.SuccessMessage;
        }

        public async Task<string> AcceptTransfer(TransferBatchDTO transferBatchDTO)
        {

            var obj = await _iTrackingCodeRepositoryForScan.Search(o => o.TrackingCodeID == transferBatchDTO.TrackingCode).FirstOrDefaultAsync();

            if (obj == null)
            {
                throw new Exception("The object to transfer with given TrackingCode was not found");
            }

            var listOfScansForTrackingCode = await _iScanRepository.Search(o=>o.TrackingCodeID== transferBatchDTO.TrackingCode).OrderByDescending(o=>o.TimeStamp).ToListAsync();

            string transferType = "None";

            for (var i = 0; i < listOfScansForTrackingCode.Count; i++)
            {
                var loopObj = listOfScansForTrackingCode[i];
                if (loopObj.InteractionType == StaticVariables.TransferRequested || loopObj.InteractionType == StaticVariables.TransferAccepted)
                {
                    transferType= loopObj.InteractionType;
                    break;
                }
            }


            if (transferType == "None" || transferType == StaticVariables.TransferAccepted)
            {
                throw new Exception("No transfer request");
            }

            

            await _iScanRepository.AddAsync(new Scan()
            {
                ScanGuid = transferBatchDTO.TrackingCode,
                TrackingCodeID = transferBatchDTO.TrackingCode,
                InteractionType = StaticVariables.TransferAccepted,
                InteractionDescription = "",
                CertificateID = transferBatchDTO.CertificateId,
                UserID = transferBatchDTO.UserId,
                Latitude = transferBatchDTO.Latitude,
                Longitude = transferBatchDTO.Longitude,
                LocationName = transferBatchDTO.LocationName
            });

            return StaticVariables.SuccessMessage;
        }
    }
}
