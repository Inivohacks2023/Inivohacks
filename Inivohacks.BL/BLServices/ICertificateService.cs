﻿using Inivohacks.BL.DTOs;

namespace Inivohacks.BL.BLServices
{
    public interface ICertificateService
    {
        public Task<string> CreateCertificateAsync(CertificateDto dto);
        public IAsyncEnumerable<CertificateDto> GetCertificatesByProductIdAsync(int productId);
        public Task<CertificateDto> GetCertificateByTokenAsync(string token);
        public IAsyncEnumerable<CertificateDto> GetAllCertificatesAsync(); //Not Used
        public Task<bool> RevokeCertificate(string token);
    }
}