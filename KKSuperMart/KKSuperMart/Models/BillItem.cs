using System;
namespace KKSuperMart.Models
{
    public class BillItem
    {
        public int SNo { get; set; }
        public string _id { get; set; }
        public string VCHRNO { get; set; }
        public string MCODE { get; set; }
        public string DESCA { get; set; }
        public double RATE { get; set; }
        public float Quantity { get; set; }
        public double AMOUNT { get; set; }
        public double TOTAMNT { get; set; }
        public double DCAMNT { get; set; }
        public double TAXABLE { get; set; }
        public double NONTAXABLE { get; set; }
        public double VATAMNT { get; set; }
        public double NETAMNT { get; set; }

        public static string GenerateBillItemsURL(string vchrNo, string memid, string companyid)
        {
            return string.Format(Helpers.Data.Constants.BillItemsUrl,vchrNo, memid, companyid);
        }
    }

    public class BillTotal
    {
        public double TOTAMNT { get; set; }
        public double DCAMNT { get; set; }
        public double TAXABLE { get; set; }
        public double NONTAXABLE { get; set; }
        public double VATAMNT { get; set; }
        public double NETAMNT { get; set; }
    }
}
