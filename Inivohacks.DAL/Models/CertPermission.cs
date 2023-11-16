using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inivohacks.DAL.Models
{
    public class CertPermission
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CertPermissionID { get; set; }
        public int CertificateID { get; set; }
        public int PermissionID { get; set; }
        public virtual Certificate Certificate { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
