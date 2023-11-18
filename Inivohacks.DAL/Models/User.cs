using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inivohacks.DAL.Models
{
    public class User

    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ManufacturerID { get; set; }
        public bool LoginDisabled { get; set; }
        public bool isManufacturer { get; set; }
        public bool isSupplier { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public ICollection<Scan> Scans { get; set; }
        
    }
}
