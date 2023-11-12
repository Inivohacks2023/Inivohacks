using System.Net;

namespace Inivohacks.ViewModels
{
    public class UserRequestModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
        public int ManufacturerID { get; set; }
        public bool LoginDisabled { get; set; }

    }
}
