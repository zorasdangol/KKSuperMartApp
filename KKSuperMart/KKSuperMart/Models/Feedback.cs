using System;
using Plugin.Media.Abstractions;

namespace KKSuperMart.Models
{
    public class Feedback
    {
        public string MESSAGE { get; set; }
        public string COMPANYID { get; set; }
        public string MEMBERID { get; set; }
        public MediaFile ImageUpload { get; set; }

        public Feedback()
        {
            MESSAGE = "";
            COMPANYID = "";
            MEMBERID = "";
        }
    }

    public class Message
    {
        

        public string MEMBERID { get; set; }
        public string MEMBER { get; set; }
        public DateTime DATE { get; set; }
        public string QUERY { get; set; }
        public string REPLY { get; set; }
        public string IMGURL { get; set; }
        public int REPLYID { get; set; }

        public Message()
        {
            MEMBERID = "";
            MEMBER = "";
            DATE = new DateTime();
            QUERY = "";
            REPLY = "";
            IMGURL = "";
            REPLYID = 0;
        }
        public static string GenerateChatURL(string memid, string companyid)
        {
            return string.Format(Helpers.Data.Constants.ChatUrl, memid, companyid);
        }
    }
}
