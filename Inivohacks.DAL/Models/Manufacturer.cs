using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inivohacks.DAL.Models
{
    public class Manufacturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManufacturerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string NotifyEmail { get; set; }
        public string NotifySMS { get; set; }


        public ICollection <User> Users { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
