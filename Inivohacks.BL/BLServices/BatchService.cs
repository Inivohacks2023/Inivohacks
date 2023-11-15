using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;
using Inivohacks.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inivohacks.BL.BLServices
{
    public class BatchService : IBatchService
    {
        private readonly IBatchRepository _iBatchRepository;

        public BatchService(IBatchRepository iBatchRepository)
        {
            _iBatchRepository = iBatchRepository;


        }
        public async Task<Batch> CreateBatchAsync(BatchDTO batch)
        {
            bool status = false;
            if (batch == null)
            {
                status = false;
            }
            try
            {
                Batch obj = new Batch()
                {
                    ProductId = batch.ProductId,
                    ManufacturedDate = batch.ManufacturedDate,
                    ExpiryDate = batch.ExpiryDate,
                    OriginalBatchid = batch.OriginalBatchid,
                    Qty = batch.Qty,
                    LocationId = batch.LocationId,
                    LocationName = batch.LocationName,
                };

                var returnObj = await _iBatchRepository.AddbatchAsync(obj);
                return returnObj;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<List<Batch>> GetAllBatchesAsync(int? productId)
        {
            return (await _iBatchRepository.Search(o => (productId == null || o.ProductId == productId) && !o.IsDelete).ToListAsync());
        }

        public async Task<BatchInformationDTO?> GetBatchById(int batchId)
        {
            var obj = await _iBatchRepository.Search(o => o.Id == batchId).FirstOrDefaultAsync();
            if (obj == null) return null;

            var returnObj = new BatchInformationDTO()
            {
                Id = obj.Id,
                ProductId = obj.ProductId,
                ManufacturedDate = obj.ManufacturedDate,
                ExpiryDate = obj.ExpiryDate,
                Qty = obj.Qty,
                LocationId = obj.LocationId,
                LocationName = obj.LocationName,
                Status = obj.Status,
            };
            bool originalBatchReached = false;
            int? orignalBatchID = obj.OriginalBatchid;
            do
            {
                var lastBatchObjectBeforRebrand = await _iBatchRepository.Search(o => o.Id == orignalBatchID).FirstOrDefaultAsync();
                if (lastBatchObjectBeforRebrand == null)
                {
                    orignalBatchID = 0;
                }
                else
                {
                    //  var product =  await _iBatchRepository.Search(o => o.Id == batchId).FirstOrDefaultAsync(); //get product etails
                    returnObj.RebrandHistory.Add(new RebrandHistoryRecord() { ManufacturedDate = lastBatchObjectBeforRebrand.ManufacturedDate, BatchName = "" });
                    orignalBatchID = lastBatchObjectBeforRebrand.OriginalBatchid;
                }


            } while (orignalBatchID != null && orignalBatchID != 0);
            return returnObj;
        }

        public async Task<bool> Recall(int batchId)
        {
            var obj = await _iBatchRepository.Search(o => o.Id == batchId).SingleOrDefaultAsync();

            if (obj == null)
            {
                return false;
            }
            obj.Status = "Recalled";
            await _iBatchRepository.UpdateAsync(obj);
            return true;
        }

        public async Task<bool> Delete(int batchId)
        {
            var obj = await _iBatchRepository.Search(o => o.Id == batchId).SingleOrDefaultAsync();
            if (obj == null)
            {
                return false;
            }
            obj.IsDelete = true;
            await _iBatchRepository.UpdateAsync(obj);
            return true;
        }

        public async Task<string> RebrandBatch(BatchDTO batch)
        {
            try
            {
                var batchToRebrand = await _iBatchRepository.Search(o => o.Id == batch.OriginalBatchid).SingleOrDefaultAsync();

                if (batchToRebrand == null)
                {
                    return "Old batch to rebrand was  not Found";
                }
                batchToRebrand.Status = "Rebranded";
                await _iBatchRepository.UpdateAsync(batchToRebrand);

                var rebrandedBatch = new Batch()
                {
                    ProductId = batch.ProductId,
                    ManufacturedDate = batch.ManufacturedDate,
                    ExpiryDate = batch.ExpiryDate,
                    OriginalBatchid = batch.OriginalBatchid,
                    Qty = batch.Qty,
                    LocationId = batch.LocationId,
                    LocationName = batch.LocationName,

                };
                await _iBatchRepository.AddAsync(rebrandedBatch);
                return StaticVariables.SuccessMessage;
            }
            catch (Exception e)
            {
                return e.ToString(); ;
            }
        }

        public async Task<string> UpdateOwner(int batchid, int locationId, string locationName)
        {
            var batchToRebrand = await _iBatchRepository.Search(o => o.Id == batchid).SingleOrDefaultAsync();

            if (batchToRebrand == null)
            {
                return "Batch with gicen Id not found";
            }
            batchToRebrand.LocationName = locationName;
            batchToRebrand.LocationId = locationId;
            await _iBatchRepository.UpdateAsync(batchToRebrand);
            return StaticVariables.SuccessMessage;

        }

    }
}
