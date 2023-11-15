using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inivohacks.DAL.Models
{
    public class Certificate
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CertificateID { get; set; }
        public int ProductID { get; set; }
        public bool InUse { get; set; }
        public DateTime ExpiryDate { get; set; }
       
        public virtual Product Product { get; set;}
        public ICollection<CertPermission> CertPermissions { get; set; }
        public ICollection<Scan> Scans { get; set; }
       
    }
}
