using System;
namespace KKSuperMart.Models
{
    public class Contact
    {
        public string COMPANYNAME { get; set; }
        public string CADDRESS { get; set; }
        public string CONTACTNO {get;set;}
        public string EMAIL { get; set; }
        public string WEBADDRESS { get; set; }

        public static string GenerateContactURL(string companyid)
        {
            return string.Format(Helpers.Data.Constants.ContactUrl, companyid);
        }
       
    }
}
