using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;

namespace Inivohacks.BL.BLServices
{
    public interface IBatchService
    {
        public Task<bool> CreateBatchAsync(BatchDTO batch);
        public Task<List<Batch>> GetAllBatchesAsync (int ? productId);
    }

}
