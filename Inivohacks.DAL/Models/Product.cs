using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inivohacks.DAL.Models
{
    public class Product
    {
        public Product() {

            Manufacturer = new HashSet<Manufacturer>();
        }
       public int ProductID { get; set; }
       public int ManufactureID { get; set; }
       public string Name { get; set; }
       public string Dosage { get; set; }
       public string  PType { get; set; }

        public ICollection<Manufacturer> Manufacturer { get; set; }
    }
}
