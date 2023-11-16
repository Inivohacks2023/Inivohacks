using Inivohacks.BL.DTOs;

namespace Inivohacks.BL.BLServices
{
    public interface ICodeService
    {
        Task<CodeResponseDto> GenerateCodeAsync(int NoProducts, CodeDto codeDto);
        Task<bool> SaveCustomCodeAsync(CodeDto codeDto);
    }
}