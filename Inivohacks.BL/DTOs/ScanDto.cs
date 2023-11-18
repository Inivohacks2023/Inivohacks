using Inivohacks.DAL.Models;

namespace Inivohacks.BL.DTOs
{
    public class ScanDto
    {
        public Guid ScanGuid { get; set; }
        public Guid TrackingCodeID { get; set; }
        public int UserID { get; set; }
        public string InteractionType { get; set; }
        public string InteractionDescription { get; set; }
        public int CertificateID { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
