using Inivohacks.BL.DTOs;
using Inivohacks.DAL.Models;
using Inivohacks.DAL.Repositories;
using System.Reflection.Metadata;

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
            
            Product product = await _productRepository.GetProductbyProductIdAsync(codeDto.ProductId);
            
            if (product == null)
            {
                return null;
            }

            foreach (int item in Enumerable.Range(1, NoProducts))
            {
                Guid codeId = new Guid(item, (short)codeDto.BatchNumber,(short)product.ProductID,new byte[] { 1,2,3,4,5,6,7,8});
                
                codes.Add(new TrackingCode()
                {
                    TrackingCodeID = codeId,
                    ProductID = product.ProductID,
                    Code = codeId.ToString(),
                });
            }

            return new CodeResponseDto()
            {
                NoProducts = NoProducts,
            };
        }


        public async Task<bool> SaveCustomCodeAsync(CodeDto codeDto)
        {
            List<TrackingCode> codes = new List<TrackingCode>();

            Product product = await _productRepository.GetProductbyProductIdAsync(codeDto.ProductId);

            if (product == null)
            {
                return false;
            }

            foreach (int item in Enumerable.Range(1, codeDto.Codes.Count))
            {
                Guid codeId = new Guid(item, (short)codeDto.BatchNumber, (short)product.ProductID, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 });

                codes.Add(new TrackingCode()
                {
                    TrackingCodeID = codeId,
                    ProductID = product.ProductID,
                    Code = codeDto.Codes[item],
                });
            }
            return true;
        }

        public async Task<bool> UpdateBatchBulk(CodeDto codeDto)
        {

            return true;
        }
    }
}
