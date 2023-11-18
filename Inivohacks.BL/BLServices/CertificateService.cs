using Azure.Core;
using Inivohacks.BL.DTOs;
using Inivohacks.BL.Helper;
using Inivohacks.DAL.Models;
using Inivohacks.DAL.Repositories;
using Microsoft.Extensions.Configuration;

namespace Inivohacks.BL.BLServices
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _certifiRepository;
        private readonly ICertPermission _certService;
        private readonly IConfiguration _configuration;

        public CertificateService(ICertificateRepository certificationRepository, ICertPermission certService, IConfiguration configuration)
        {
            _certifiRepository = certificationRepository;
            _certService = certService;
            _configuration = configuration;
        }

        public async Task<string> CreateCertificateAsync(CertificateDto dto)
        {
            try
            {
              Certificate cert =await  _certifiRepository.AddCertPermissionAsync(dto.TransformAPItoDAL());
                foreach (var permissionID in dto.PermissionList)
                {
                    var item = new CertPermission()
                    {

                        CertificateID = cert.CertificateID,
                        PermissionID = Convert.ToInt32(permissionID)
                    };
                    await _certService.AddAsync(item);
                }

                //var cert= await GetCertificateByIdAsync(certId);
                return cert.Token;
            }
            catch (Exception ex)
            {
            }

            return string.Empty; 
        }

        public IAsyncEnumerable<CertificateDto> GetAllCertificatesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CertificateDto> GetCertificateByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CertificateDto> GetCertificateByTokenAsync(string token)
        {
            try { 
                Certificate cert = await _certifiRepository.GetCertificateByTokenAsync(token);
                return cert.TransformDALtoAPI();
            }
            catch { return null; }
        }

        public async IAsyncEnumerable<CertificateDto> GetCertificatesByProductIdAsync(int productId)
        {
            IAsyncEnumerable<Certificate> certificateList = _certifiRepository.GetAllCertificateAsync(productId);
            await foreach (var cert in certificateList)
            {
                yield return cert.TransformDALtoAPI();
            }
        }
    }
}