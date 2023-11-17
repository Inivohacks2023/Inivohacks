using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inivohacks.DAL.Models
{
    public class TrackingCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TrackingCodeID { get; set; }
        public int ProductID { get; set; }

        public string Code { get; set; } = "Active";
        public string Status { get; set; } = "Active";

        public int BatchNumber { get; set; }

        public int SerialNumber { get; set; }

        public string Notes { get; set; } = "";
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiredDate { get; set; }

        public bool RecallStatus { get; set; } = false;
        public DateTime TrackingCodeCreatedTimeStamp { get; set; } = DateTime.Now;
        
        public Product Product { get; set; }
        
        public ICollection<Scan> Scans { get; set; }
       

    }
}
