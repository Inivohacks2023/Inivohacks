using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.DAL.Models
{
    public class User

    {
        public User()
        {
            Manufacturers = new HashSet<Manufacturer>();
        }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ManufacturerID { get; set; }
        public bool LoginDisabled { get; set; }

        public ICollection<Manufacturer> Manufacturers { get; set; }
    }
}
