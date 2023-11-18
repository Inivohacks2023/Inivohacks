using Inivohacks.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.DTOs
{
    public  class CertificateCertPermissionDto
    {
       

        public CertificateDto CertificateDetails { get; set; }
        public string PermisionDetails { get; set; }
        
    }
}
