using System;
namespace KKSuperMart.Models
{
    public class Branch
    {
        public int BID { get; set; }
        public string NAME { get; set; }
        public string ADDRESS { get; set; }
        public string CONTACT_NO { get; set; }
        public string LONGITUDE { get; set; }
        public string LATITUDE { get; set; }

        public static string GenerateBranchesURL(string companyid)
        {
            return string.Format(Helpers.Data.Constants.BranchesUrl, companyid);
        }
    }
}
