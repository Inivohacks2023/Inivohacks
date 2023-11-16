using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.DTOs.Models
{
    public class TransferBatchDTO
    {
        public Guid TrackingCode { get; set; }
        public int NewOwner { get; set; }
        public int CertificateId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string LocationName { get; set; }
    }
}
