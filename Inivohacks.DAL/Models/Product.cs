using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inivohacks.DAL.Models
{
    public class Product
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        public int ManufacturerID { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string  PType { get; set; }

        public  Manufacturer Manufacturer { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<TrackingCode> TrackingCodes { get; set; }

    }
}
