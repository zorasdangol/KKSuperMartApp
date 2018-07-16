using System;
namespace KKSuperMart.Models
{
    public class DeviceToken
    {
        public string email { get; set; }
        public string mobile { get; set; }
        public string otp { get; set; }
        public string deviceToken { get; set; }
        public string companyid { get; set; }
        public string mode { get; set; }

        public DeviceToken()
        {
        }

       
    }
}
