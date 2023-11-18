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
        public string Code { get; set; }
        public int BatchNumber { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string LocationName { get; set; }
        public int UserId { get; set; }


    }
}
