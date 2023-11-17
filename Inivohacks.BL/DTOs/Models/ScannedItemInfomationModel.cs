using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.DTOs.Models
{
    public class ScannedItemInfomationModel
    {
        public Guid TrackingCodeID { get; set; }
        public string ProductName { get; set; }
        public string Dosage { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerAddress { get; set; }
        public string RecallStatus { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string LastAvailablelocation { get; set; }
    }
}
