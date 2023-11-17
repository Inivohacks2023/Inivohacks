using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inivohacks.DAL.Models
{
    public class Scan
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int ScanID { get; set; }

        public Guid ScanGuid { get; set; }
        public Guid TrackingCodeID { get; set; }
        public int UserID { get; set; }
        public string InteractionType { get; set; }
        public string InteractionDescription { get; set; }
        public int CertificateID { get; set; }
        public DateTime TimeStamp { get; set; }=DateTime.Now;
        

		public virtual User User { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string LocationName { get; set; }
        public virtual TrackingCode TrackingCode { get; set; }
        public virtual Certificate Certificate { get; set; }
        
    }
}
