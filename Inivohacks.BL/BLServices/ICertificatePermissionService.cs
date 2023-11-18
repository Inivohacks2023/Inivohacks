using Inivohacks.BL.DTOs;

namespace Inivohacks.BL.BLServices
{
    public interface ICertificatePermssionsService
    {
        public Task<bool> CreateCertificatePermissions(CertificatePermissionDto dto);
        public Task<CertificatePermissionDto> GetCertificatePermissionByIdAsync(int id);
    }
}