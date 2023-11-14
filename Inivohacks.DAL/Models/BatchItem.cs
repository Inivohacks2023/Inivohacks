using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inivohacks.DAL.Models
{
  
    public class BatchItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BatchId { get; set; }
        public int Qty { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
