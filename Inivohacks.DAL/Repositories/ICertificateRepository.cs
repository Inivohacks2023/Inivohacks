using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.DAL.Repositories
{
    public interface ICertificateRepository :IRepository<Certificate>
    {
        public Task<Certificate> AddCertPermissionAsync(Certificate certificate);

        public Task<Certificate> GetCertificateByTokenAsync(string token);
        
        public IAsyncEnumerable<Certificate> GetAllCertificateAsync(int productID);
        public bool RevokeCertificate(string token);
    }
}
