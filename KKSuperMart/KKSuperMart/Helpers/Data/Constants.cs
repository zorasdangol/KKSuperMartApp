using System;
namespace KKSuperMart.Helpers.Data
{
    public class Constants
    {
        public const string CompanyId = "5a8a9991158335e5f09db777";
        //public const string DeviceToken = "sarojdangol1234";

        public const string PromotionsUrl = "http://imsnepal.com:8080/imsposmem/api/promotions?companyid={0}";
        public const string PurchaseItemsUrl = "http://imsnepal.com:8080/imsposmem/api/tran?memid={0}&companyid={1}";
        public const string BillItemsUrl = "http://imsnepal.com:8080/imsposmem/api/tran?vchrNo={0}&memid={1}&companyid={2}";
        public const string AdvertisementsUrl = "http://imsnepal.com:8080/imsposmem/api/advertisement?companyid={0}";
        public const string BranchesUrl = "http://imsnepal.com:8080/imsposmem/api/mbranch?companyid={0}";
        public const string MyPointsUrl = "http://imsnepal.com:8080/imsposmem/api/points?memid={0}&companyid={1}";
        public const string TeamMembersUrl = "http://imsnepal.com:8080/imsposmem/api/teamMember?companyid={0}";
        public const string CouponsUrl = "http://imsnepal.com:8080/imsposmem/api/coupon?memid={0}&companyid={1}";
        public const string ContactUrl = "http://imsnepal.com:8080/imsposmem/api/companyinfo?companyid={0}";
        public const string SignInUrl = "http://imsnepal.com:8080/imsposmem/api/tran?email={0}&mobile={1}&companyid={2}";

        public const string DeviceTokenUrl = "http://imsnepal.com:8080/imsposmem/api/devicetoken?";
        public const string InquiryUrl = "http://imsnepal.com:8080/imsposmem/api/Queries?";
        public const string FeedbackUrl = "http://imsnepal.com:8080/imsposmem/api/feedback?";

        public const string ChatUrl = "http://imsnepal.com:8080/imsposmem/api/messages?memberid={0}&companyid={1}";

    }
}
