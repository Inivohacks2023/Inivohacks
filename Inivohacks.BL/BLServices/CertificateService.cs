using Inivohacks.BL.DTOs;
using Inivohacks.BL.Helper;
using Inivohacks.DAL.Models;
using Inivohacks.DAL.Repositories;

namespace Inivohacks.BL.BLServices
{
    public class CertificateService : ICertificateService
    {
        private readonly IPermissionRepository _permissionRepository;

        public CertificateService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public Task<bool> CreateCertificateAsync(CertificateDto dto)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<CertificateDto> GetAllCertificatesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CertificateDto> GetCertificateByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CertificateDto> GetCertificateByTokenAsync(string token)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<CertificateDto> GetCertificatesByProductIdAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}