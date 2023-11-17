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
        public async Task<ScannedItemInfomationModel?> GetItemInformation(Guid guId)
        {
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
                CertificateID = 8,
                UserID = 3,
            });

            return new ScannedItemInfomationModel()
            {
                TrackingCodeID = guId,
                ProductName = obj.Product.Name,
                Dosage = obj.Product.Dosage,
                ManufacturerAddress = obj.Product.Manufacturer.Address,
                ManufacturerName = obj.Product.Manufacturer.Name,
                RecallStatus = obj.RecallStatus == true ? "Product is recalled" : "Product is valid and has passed necessary quality controls"


            };
        }

        public async Task<Guid> Rebrand(RebrandTrackerCodeDTO rebrandData)
        {

            var obj = await _iTrackingCodeRepositoryForScan.Search(o => o.TrackingCodeID == rebrandData.CurrentTrackingCodeID).FirstOrDefaultAsync();

            if (obj == null)
            {
                throw new Exception("The object to rebrand with given CurrentTrackingCodeID was not found");
            }

            obj.Status = "Rebranded";
            await _iTrackingCodeRepositoryForScan.UpdateAsync(obj);

            TrackingCode rebrandedTrackingCode = new()
            {
                ProductID = rebrandData.ProductId,

            };

            await _iTrackingCodeRepositoryForScan.AddAsync(rebrandedTrackingCode);

            await _iScanRepository.AddAsync(new Scan()
            {
                ScanGuid = rebrandData.CurrentTrackingCodeID,
                TrackingCodeID = rebrandedTrackingCode.TrackingCodeID,
                InteractionType = "Rebrand",
                InteractionDescription = "",
                CertificateID = rebrandData.CertificateId,
                UserID = 3,
            });


            return rebrandedTrackingCode.TrackingCodeID;
        }

        public async Task<string> Recall(RecallDTO model)
        {
            var obj = await _iTrackingCodeRepositoryForScan.Search(o => o.BatchNumber == model.BatchId).FirstOrDefaultAsync();

            if (obj == null)
            {
                throw new Exception("The object to rebrand with given guId was not found");
            }
            await _iScanRepository.AddAsync(new Scan()
            {/*
                BA= model.BatchId,
                TrackingCodeID = model.GuId,*/
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

        public async Task<string> TransferItem(TransferBatchDTO transferBatchDTO)
        {

            var obj = await _iTrackingCodeRepositoryForScan.Search(o => o.TrackingCodeID == transferBatchDTO.TrackingCode).FirstOrDefaultAsync();

            if (obj == null)
            {
                throw new Exception("The object to transfer with given TrackingCode was not found");
            }


            await _iScanRepository.AddAsync(new Scan()
            {
                ScanGuid = transferBatchDTO.TrackingCode,
                TrackingCodeID = transferBatchDTO.TrackingCode,
                InteractionType = "TransferAccepted",
                InteractionDescription = "",
                CertificateID = transferBatchDTO.CertificateId,
                UserID = 3,
                Latitude= transferBatchDTO.Latitude,
                Longitude= transferBatchDTO.Longitude,
                LocationName = transferBatchDTO.LocationName
            });

            return StaticVariables.SuccessMessage;
        }
    }
}
