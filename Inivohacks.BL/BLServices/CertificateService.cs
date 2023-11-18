using Azure.Core;
using Inivohacks.BL.DTOs;
using Inivohacks.BL.Helper;
using Inivohacks.DAL.Models;
using Inivohacks.DAL.Repositories;

namespace Inivohacks.BL.BLServices
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _certifiRepository;
        private readonly ICertPermission _certService;

        public CertificateService(ICertificateRepository certificationRepository, ICertPermission certService)
        {
            _certifiRepository = certificationRepository;
            _certService = certService;
        }

        public async Task<bool> CreateCertificateAsync(CertificateDto dto)
        {
            bool status = false;
            try
            {
              int certId=await  _certifiRepository.AddCertPermissionAsync(dto.TransformAPItoDAL());
                foreach (var permissionID in dto.PermissionList)
                {
                    var item = new CertPermission()
                    {

                        CertificateID = certId,
                        PermissionID = Convert.ToInt32(permissionID)
                    };
                    await _certService.AddAsync(item);
                }
                status= true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
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