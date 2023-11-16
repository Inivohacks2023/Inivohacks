namespace Inivohacks.BL.DTOs
{
    public class BatchInformationDTO
    {
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
   
        public int Qty { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        /// <summary>
        /// Status of product:"OK"/"Recalled"/"Rebranded"
        /// </summary>
        public string Status { get; set; } = "Ok";
        public List<RebrandHistoryRecord> RebrandHistory { get; set; }= new List<RebrandHistoryRecord>();

    }

    public class RebrandHistoryRecord
    {
        public DateTime ManufacturedDate { get; set; }
        /// <summary>
        /// New name
        /// </summary>
        public string BatchName { get; set;}
        
    }
}
