namespace Inivohacks.BL.DTOs
{
    public class BatchItemDTO
    {
        public int Id { get; set; }
        public int BatchId { get; set; }
        public int Qty { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
