using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.DTOs
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
        public int ManufacturerID { get; set; }
        public bool LoginDisabled { get; set; }
    }
}
