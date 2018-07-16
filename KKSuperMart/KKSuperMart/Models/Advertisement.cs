using System;
namespace KKSuperMart.Models
{
    public class Advertisement
    {
        public int AID { get; set; }
        public string IMAGEURL { get; set; }
        public DateTime BEGINDATE { get; set; }
        public DateTime ENDDATE { get; set; }
        public string WEBSITE { get; set; }
        public string FDate { get; set; }
        public string TDate { get; set; }
        public object ImageUpload { get; set; }
        public string COMPANYID { get; set; }

        public static string GenerateAdvertisementsURL(string companyid)
        {
            return string.Format(Helpers.Data.Constants.AdvertisementsUrl, companyid);
        }

       
    }
  
}
