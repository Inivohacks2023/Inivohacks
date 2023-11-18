using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.DTOs
{
    public class CertificateDto
    {
        public int CertificateID { get; set; }
        public int ProductID { get; set; }
        public bool InUse { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<CertificatePermissionDto> CertificatePermissions { get; set; }
        public string Token { get; set; }
    }
}
