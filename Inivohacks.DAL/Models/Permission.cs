using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inivohacks.DAL.Models
{
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionId { get; set; }
        public string PermissionDescription { get; set; }
        public string PermissionCode { get; set; }
        public ICollection<CertPermission> CertPermissions { get; set; }
    }
}
