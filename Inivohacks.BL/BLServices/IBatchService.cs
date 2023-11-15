using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;

namespace Inivohacks.BL.BLServices
{
    public interface IBatchService
    {
        public Task<Batch> CreateBatchAsync(BatchDTO batch);
        public Task<List<Batch>> GetAllBatchesAsync (int ? productId);

        public Task<BatchInformationDTO> GetBatchById(int batchId);
        public Task<bool> Recall(int batchId);
        public Task<bool> Delete(int batchId);
        public Task<string> RebrandBatch(BatchDTO batch);
        public Task<string> UpdateOwner(int batchid,int locationId,string locationName);
    }

}
