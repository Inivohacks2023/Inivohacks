using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inivohacks.DAL.Models
{
    public class Scan
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public Guid ScanID { get; set; }
        public Guid TrackingCodeID { get; set; }
        public int UserID { get; set; }
        public string InteractionType { get; set; }
        public int InteractionDescription { get; set; }
        public int CertificateID { get; set; }
        

        public virtual User User { get; set; }
        public virtual TrackingCode TrackingCode { get; set; }
        public virtual Certificate Certificate { get; set; }
        
    }
}
