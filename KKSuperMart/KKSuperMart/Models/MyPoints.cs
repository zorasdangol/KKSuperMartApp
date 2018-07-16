using System;
using System.Collections.Generic;

namespace KKSuperMart.Models
{
    public class MyPoints
    {
        public double totalPointsDeducted { get; set; }
		public double points { get; set; }
        public double totalPointsGained { get; set; }
        public List<PointsDetail> details { get; set; }

        public static string GenerateMyPointsURL(string memid,string companyid)
        {
            return string.Format(Helpers.Data.Constants.MyPointsUrl, memid, companyid);
        }
    }

    public class PointsDetail
    {
        public DateTime trndate { get; set; }
        public string trntime { get; set; }
        public string vchrno { get; set; }
        public string div { get; set; }
        public string fiscalid { get; set; }
        public double billamount { get; set; }
        public double pointableamount { get; set; }
        public double points { get; set; }
        public double pointsgained { get; set; }
        public double pointsdeducted { get; set; }
        public string user { get; set; }
    }

}
