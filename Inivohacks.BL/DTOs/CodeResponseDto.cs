using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.DTOs
{
    public class CodeResponseDto
    {
        public int ProductId { get; set; }
        public int BatchNumber { get; set; }
        public int NoProducts { get; set; }

        public List<String> Codes { get; set; }
    }
}
