namespace Inivohacks.ViewModels
{
    public class AddCodesRequestModel
    {
        public int ProductId { get; set; }
        public int BatchNumber { get; set; }
        public int SerialNumber { get; set; }
        public List<String> Codes { get; set; }
        public string Notes { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiredDate { get; set; }

    }
}
