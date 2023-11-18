using Inivohacks.BL.DTOs;
using Inivohacks.BL.Helper;
using Inivohacks.DAL.Models;
using Inivohacks.DAL.Repositories;

namespace Inivohacks.BL.BLServices
{
    public class CertificatePermissionService : ICertificatePermssionsService
    {
        private readonly IPermissionRepository _permissionRepository;


        public CertificatePermissionService(IPermissionRepository  permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public Task<bool> CreateCertificatePermissions(CertificatePermissionDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<CertificatePermissionDto> GetCertificatePermissionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}