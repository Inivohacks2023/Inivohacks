namespace Inivohacks.ViewModels
{
    public class BatchRequestModel
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
