using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;
using Inivohacks.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.BLServices
{
    public class BatchService : IBatchService
    {
        private readonly IBatchRepository _iBatchRepository;

        public BatchService(IBatchRepository iBatchRepository)
        {
            _iBatchRepository = iBatchRepository;


        }
        public async Task<bool> CreateBatchAsync(BatchDTO batch)
        {
            bool status = false;
            if (batch == null)
            {
                status = false;
            }
            try
            {
                Batch obj = new Batch() {
                    ProductId=batch.ProductId,
                    ManufacturedDate=batch.ManufacturedDate,
                    ExpiryDate=batch.ExpiryDate,
                    OriginalBatchid=batch.OriginalBatchid,
                    Qty=batch.Qty
                };
               
                _iBatchRepository.AddAsync(obj);
                status = true;
            }
            catch
            {
                status = false;
            }
            return status;
        }
    }
}
