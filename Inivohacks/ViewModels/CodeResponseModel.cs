namespace Inivohacks.ViewModels
{
    public class CodeResponseModel
    {
        public string BatchNumber { get; set; }
        public int NoProducts { get; set; }

        public List<Guid> Codes { get; set; }
    }
}
