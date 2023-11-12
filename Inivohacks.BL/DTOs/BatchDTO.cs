using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inivohacks.BL.DTOs
{
    public class BatchDTO
    {
        public int ProductId { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        /// <summary>
        /// If batch was rebranded the batch no of original  batch
        /// </summary>
        public int? OriginalBatchid { get; set; }
        public int Qty { get; set; }
    }
}
