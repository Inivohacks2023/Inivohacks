using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Inivohacks.DAL.Models
{
    public class Batch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Product table ID
        /// </summary>
        public int ProductId { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        /// <summary>
        /// If batch was rebranded the batch no of original  batch
        /// </summary>
        public int? OriginalBatchid { get; set; }
        public int Qty { get; set; }
        /// <summary>
        /// Status of product:"OK"/"Recalled"
        /// </summary>
        public string Status { get; set; } = "Ok";
    }
}
