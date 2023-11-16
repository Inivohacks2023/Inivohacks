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
                InteractionDescription = 1,
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
                InteractionDescription = 1,
                CertificateID = rebrandData.CertificateId,
                UserID = 3,
            });


            return rebrandedTrackingCode.TrackingCodeID;
        }

        public async Task<string> Recall(Guid guId)
        {
            var obj = await _iTrackingCodeRepositoryForScan.Search(o => o.TrackingCodeID == guId).FirstOrDefaultAsync();

            if (obj == null)
            {
                throw new Exception("The object to rebrand with given guId was not found");
            }

            obj.RecallStatus = true;
            await _iTrackingCodeRepositoryForScan.UpdateAsync(obj);

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
                InteractionDescription = 1,
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
