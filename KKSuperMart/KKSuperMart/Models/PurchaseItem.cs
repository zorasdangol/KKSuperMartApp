using System;
namespace KKSuperMart.Models
{
    public class PurchaseItem
    {
        public object _id { get; set; }
        public string VCHRNO { get; set; }
        public string Date { get; set; }
        public double Amount { get; set; }
        public string Branch { get; set; }

        public static string GeneratePurchaseItemsURL(string memid,string companyid)
        {
            return string.Format(Helpers.Data.Constants.PurchaseItemsUrl, memid, companyid);
        }
    }
}
