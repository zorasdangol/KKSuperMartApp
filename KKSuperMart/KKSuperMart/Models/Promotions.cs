using System;
using System.Collections.Generic;

namespace KKSuperMart.Models
{
    public class Promotions
    {
        public IDType _id { get; set; }
        public List<ProductType> products { get; set; }

        public static string GeneratePromotionsURL(string companyid)
        {
            return string.Format(Helpers.Data.Constants.PromotionsUrl, companyid);
        }
    }

    public class IDType
    {
        public int _id { get; set; }
        public string CNAME { get; set; }
    }

    public class ProductType
    {
        public string PRODUCTID { get; set; }
        public string DESCRIPTION { get; set; }
        public string IMAGEURL { get; set; }
        public string MESSAGE { get; set; }
    }

   
}
