using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.DTOs.Models
{
    public class RebrandTrackerCodeDTO
    {
        public Guid CurrentTrackingCodeID { get; set; }
      
        public int ProductId { get; set; }
        public int CertificateId { get; set; }

    }
}
