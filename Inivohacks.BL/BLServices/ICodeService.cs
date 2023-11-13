using Inivohacks.BL.DTOs;

namespace Inivohacks.BL.BLServices
{
    public interface ICodeService
    {
        CodeResponseDto GenerateCodeAsync(int NoProducts,int ProductId);
        void SaveCustomCodeAsync(CodeDto codeDto);
    }
}
