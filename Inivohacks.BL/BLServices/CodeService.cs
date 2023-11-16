using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;
using Inivohacks.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Inivohacks.BL.BLServices
{
    public class CodeService : ICodeService
    {
        private readonly ITrackingCodeRepository _trackingCodeRepository;
        private readonly IProductRepository _productRepository;
        public CodeService(ITrackingCodeRepository trackingCodeRepository, IProductRepository productRepository)
        {
            _trackingCodeRepository = trackingCodeRepository;
            _productRepository = productRepository;
        }

        public async Task<CodeResponseDto> GenerateCodeAsync(int NoProducts,CodeDto codeDto)
        {
            List<TrackingCode> codes = new List<TrackingCode>();
            List<string> guids = new List<string>();
            Product product = await _productRepository.GetProductbyProductIdAsync(codeDto.ProductId);
            
            if (product == null)
            {
                return null;
            }

            if (await ValidateProductBatchId(codeDto.ProductId, codeDto.BatchNumber))
            {
                return null;
            }

            foreach (int item in Enumerable.Range(1, NoProducts))
            {
                Guid codeId = new Guid(item, (short)codeDto.BatchNumber,(short)product.ProductID,new byte[] { 1,2,3,4,5,6,7,8});
                guids.Add(codeId.ToString());
                codes.Add(new TrackingCode()
                {
                    TrackingCodeID = codeId,
                    ProductID = product.ProductID,
                    Code = codeId.ToString(),
                    Product = product,
                    SerialNumber = codeDto.SerialNumber,
                    BatchNumber = codeDto.BatchNumber,
                });
            }

            await _trackingCodeRepository.AddTrackingCodeBulkAsync(codes);

            return new CodeResponseDto()
            {
                NoProducts = NoProducts,
                ProductId = product.ProductID,
                BatchNumber = codeDto.BatchNumber,
                Codes = guids,
            };
        }


        public async Task<CodeResponseDto> SaveCustomCodeAsync(CodeDto codeDto)
        {
            List<TrackingCode> codes = new List<TrackingCode>();

            Product product = await _productRepository.GetProductbyProductIdAsync(codeDto.ProductId);

            if (product == null)
            {
                return null;
            }

            if (await ValidateProductBatchId(codeDto.ProductId,codeDto.BatchNumber))
            {
                return null;
            }

            foreach (int item in Enumerable.Range(1, codeDto.Codes.Count))
            {
                Guid codeId = new Guid(item, (short)codeDto.BatchNumber, (short)product.ProductID, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 });

                codes.Add(new TrackingCode()
                {
                    TrackingCodeID = codeId,
                    ProductID = product.ProductID,
                    Code = codeDto.Codes[item-1],
                    Product = product,
                    SerialNumber = codeDto.SerialNumber,
                    BatchNumber = codeDto.BatchNumber,
                });
            }

            await _trackingCodeRepository.AddTrackingCodeBulkAsync(codes);

            return new CodeResponseDto()
            {
                NoProducts = codeDto.Codes.Count,
                ProductId = product.ProductID,
                BatchNumber = codeDto.BatchNumber,
                Codes = codeDto.Codes,
            };
        }

        public async Task<CodeResponseDto> GetCodesByBatch(int batchNumber,int productId)
        {
            var Codes = await _trackingCodeRepository.Search(c=>c.BatchNumber == batchNumber && c.ProductID == productId).ToListAsync();

            return new CodeResponseDto()
            {
                NoProducts = Codes.Count,
                BatchNumber = batchNumber,
                ProductId = productId,
                Codes = Codes.Select(e=>e.Code.ToString()).ToList(),
            };
        }

        public async Task<bool> ValidateProductBatchId(int productId, int batchNo)
        {
            var trackingCodes = await _trackingCodeRepository.Search(e=>e.ProductID == productId && e.BatchNumber==batchNo).ToListAsync();
            return trackingCodes.Count > 0;
        }
    }
}
