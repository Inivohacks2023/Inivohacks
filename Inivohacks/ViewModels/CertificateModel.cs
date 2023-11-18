namespace Inivohacks.ViewModels
{
    public class CertificateModel
    {
        public int CertificateID { get; set; }
        public int ProductID { get; set; }
        public bool InUse { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<int> PermissionList{ get; set; }
        public string Token { get; set; }
    }
}
