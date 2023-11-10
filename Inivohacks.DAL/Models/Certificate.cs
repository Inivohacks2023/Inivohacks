using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.DAL.Models
{
    public class Certificate
    {
        public Certificate() 
        {
            Product = new HashSet<Product>();
        }
        public int CertificationID { get; set; }
        public int ProductID { get; set; }
        public bool InUse { get; set; }
        public DateTime ExpiryDate { get; set; }

        ICollection<Product> Product { get; set;}
    }
}
