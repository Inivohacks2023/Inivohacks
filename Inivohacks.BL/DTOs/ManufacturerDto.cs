using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.DTOs
{
    public class ManufacturerDto
    {
        public int ManufacturerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string NotifyEmail { get; set; }
        public string NotifySMS { get; set; }
    }
}
