using Inivohacks.BL.DTOs;

namespace Inivohacks.BL.BLServices
{
    public interface ICertificateService
    {
        public Task<bool> CreateCertificateAsync(CertificateDto dto);
        public IAsyncEnumerable<CertificateDto> GetCertificatesByProductIdAsync(int productId);
        public Task<CertificateDto> GetCertificateByTokenAsync(string token);
        public IAsyncEnumerable<CertificateDto> GetAllCertificatesAsync(); //Not Used
    }
}