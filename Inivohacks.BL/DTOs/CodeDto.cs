namespace Inivohacks.BL.DTOs
{
    public class CodeDto
    {
        public int BatchNumber { get; set; }
        public int SerialNumber { get; set; }
        public List<String> Codes { get; set; }
        public int ProductId { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public bool RecallStatus { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
