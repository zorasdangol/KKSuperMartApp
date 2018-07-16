using System;
using System.Collections.Generic;
using System.IO;
using KKSuperMart.Models;
using KKSuperMart.Views;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace KKSuperMart.Helpers.Data
{
    public static class Data
    {
        public static MenuItems SelectedMenu { get; set; }
        public static List<PurchaseItem> PurchaseItems { get; set; }
        public static List<Promotions> Promotions { get; set; }
        public static List<Advertisement> Advertisements { get; set; }
        public static List<Branch> BranchesList { get; set; }
        public static Branch SelectedBranch { get; set; }
        public static MyPoints MyPoints { get; set; }
        public static List<TeamMember> TeamMembers { get; set; }
        public static List<Coupon> Coupons { get; set; }
        public static Coupon SelectedCoupon { get; set; }
        public static Contact Contact { get; set; }
        public static string DeviceToken { get; set; }
        public static MemberDetails MemberDetails { get; set; }
        public static List<Message> ChatMessages { get; set; }

        public static MediaFile QueryImage { get; set; }

        public static UserDetails UserDetails { get; set; }
        public static string Mode { get; set; }
        public static string QRURL { get; set; }

        public static PurchaseItem SelectedPurchaseItem { get; set; }
       
        public static List<MenuItems> MenuList = new List<MenuItems>()
        {
            new MenuItems(){Index = 0,  IsSeperatorVisible =SeparatorVisibility.None, IconSource="myProfileWhite.png", Name = "My Profile", TargetType = typeof(MyProfilePage)},
            new MenuItems(){Index = 1,  IsSeperatorVisible =SeparatorVisibility.None, IconSource="purchaseListWhite.png", Name = "Purchase List", TargetType = typeof(PurchaseListPage)},
            new MenuItems(){Index = 2,  IsSeperatorVisible =SeparatorVisibility.None, IconSource = "myPointsWhite.png" , Name = "My Points",TargetType = typeof(MyPointsPage)},
            new MenuItems(){Index = 3,  IsSeperatorVisible =SeparatorVisibility.None, IconSource = "couponWhite.png" , Name = "Coupons",TargetType = typeof(CouponsPage)},
            new MenuItems(){Index = 4,  IsSeperatorVisible =SeparatorVisibility.None, IconSource = "myQRCodeWhite.png" , Name = "My QR Code",TargetType = typeof(MainHomePage)},
            new MenuItems(){Index = 5,  IsSeperatorVisible =SeparatorVisibility.None, IconSource = "companyProfileWhite.png" , Name = "Company Profile",TargetType = typeof(CompanyProfilePage)},
            new MenuItems(){Index = 6,  IsSeperatorVisible =SeparatorVisibility.None, IconSource = "branchesWhite.png" , Name = "Branches",TargetType = typeof(BranchesPage)},
            new MenuItems(){Index = 7,  IsSeperatorVisible =SeparatorVisibility.None, IconSource = "teamMembersWhite.png" , Name = "Team Members",TargetType = typeof(TeamMembersPage)},
            new MenuItems(){Index = 8,  IsSeperatorVisible =SeparatorVisibility.None, IconSource = "contactUsWhite.png" , Name = "Contact Us",TargetType = typeof(ContactUsPage)},
            new MenuItems(){Index = 9,  IsSeperatorVisible =SeparatorVisibility.Default, IconSource = "inquiryWhite.png" , Name = "Inquiry",TargetType = typeof(InquiryPage)},
            new MenuItems(){Index = 10, IsSeperatorVisible =SeparatorVisibility.None,  IconSource = "feedbackWhite.png" ,Name = "Feedback",TargetType = typeof(FeedbackPage)},
            new MenuItems(){Index = 11, IsSeperatorVisible =SeparatorVisibility.None,  IconSource = "logoutWhite.png" ,Name = "Log Out",TargetType = typeof(MainHomePage)}
        };



   }
}
