using System;
namespace KKSuperMart.Models
{
    public class Coupon
    {
        public string _id { get; set; }
        public string couponNo { get; set; }
        public string couponName { get; set; }
        public string couponPoints { get; set; }
        public string value { get; set; }
        public string issuedDate { get; set; }
        public DateTime expiryDate { get; set; }
        public string QRCodeImagePath { get; set; }

        public static string GenerateCouponsURL(string memid,string companyid)
        {
            return string.Format(Helpers.Data.Constants.CouponsUrl,memid, companyid);
        }
    }
}
