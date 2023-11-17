using Inivohacks.BL.DTOs;

namespace Inivohacks.BL.BLServices
{
    public interface ICodeService
    {
        Task<CodeResponseDto> GenerateCodeAsync(int NoProducts, CodeDto codeDto);
        Task<CodeResponseDto> SaveCustomCodeAsync(CodeDto codeDto);
        Task<CodeResponseDto> GetCodesByBatch(int batchNumber, int productId);
    }
}