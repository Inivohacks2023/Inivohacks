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
        Task<int> AddCertPermissionAsync(Certificate certificate);
        public IAsyncEnumerable<Certificate> GetAllCertificateAsync(int productID);
    }
}
