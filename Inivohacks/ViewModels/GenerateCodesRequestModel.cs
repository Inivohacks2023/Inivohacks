namespace Inivohacks.ViewModels
{
    public class GenerateCodesRequestModel
    {
        public int ProductId { get; set; }
        public int BatchNumber { get; set; }
        public int SerialNumber { get; set; }
        public int NoProducts { get; set; }
        public string Notes { get; set; }
    }
}
