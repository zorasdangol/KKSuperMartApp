using System;
namespace KKSuperMart.Models
{
    public class MemberDetails
    {
        //public string id { get; set; }
        //public string guid { get; set; }
        public string companyid { get; set; }
        public string memid { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string uname { get; set; }
        public string email { get; set; }
        public string pwd { get; set; }
        public string mob { get; set; }
        public string phone { get; set; }
        public string sex { get; set; }
        public string agegroup { get; set; }
        public string scheme { get; set; }
        public DateTime dob { get; set; }

        public addredd_detail add { get; set; }

        public string QRCodePath { get; set; }

        public MemberDetails()
        {
            dob = DateTime.Today;
            add = new addredd_detail();
        }

        public static string GenerateSignInURL(string email, string mobile, string companyid)
        {
            return string.Format(Helpers.Data.Constants.SignInUrl, email, mobile, companyid);
        }

    }

    public class UserDetails
    {
        public string companyid { get; set; }
        public string memid { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string uname { get; set; }
        public string email { get; set; }
        public string mob { get; set; }
        public string sex { get; set; }
        public DateTime dob { get; set; }
        public string QRCodePath { get; set; }
        public string DeviceToken { get; set; }
        public string zone { get; set; }
        public string dist { get; set; }
        public string street { get; set; }
        public string tole { get; set; }
        public string hno { get; set; }


    }


    public class addredd_detail
    {
        public string zone { get; set; }
        public string dist { get; set; }
        public string street { get; set; }
        public string tole { get; set; }
        public string hno { get; set; }
    }

    public class LoginDetails
    {
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string CompanyId { get; set; }
    }

    public class SignInResponse
    {
        public string status { get; set; }
        public string result { get; set; }
    }

   
}
