using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.DTOs.Models
{
    public class TrackingCodeDTO
    {
        public Guid TrackingCodeID { get; set; }
        public int ProductID { get; set; }

        public string Code { get; set; }
        public string Status { get; set; }

        public int BatchNumber { get; set; }

        public int SerialNumber { get; set; }

        public string Notes { get; set; }

        public bool RecallStatus { get; set; }
    }
}
