using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.DTOs
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        public int ManufactureID { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string PType { get; set; }
    }
}
