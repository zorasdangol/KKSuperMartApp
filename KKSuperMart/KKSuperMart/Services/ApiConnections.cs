using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using KKSuperMart.Models;
using Newtonsoft.Json;

namespace KKSuperMart.Services
{
    public class ApiConnections
    {
        public ApiConnections()
        {
        }

        public static async Task<bool> LoadAdvertisements()
        {
            try
            {
                String url = Advertisement.GenerateAdvertisementsURL(Helpers.Data.Data.MemberDetails.companyid);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    var Advertisements = JsonConvert.DeserializeObject<List<Advertisement>>(json);
                    Helpers.Data.Data.Advertisements = Advertisements;
                    return true;
                }

            }
            catch (Exception e)
            {
                //await App.Current.MainPage.DisplayAlert("Error", "Cannot connect to server:\n" + e.Message, "Ok");
                return false;
            }
        }

        public static async Task<bool> LoadPurchaseList()
        {
            try
            {
                string url = PurchaseItem.GeneratePurchaseItemsURL(Helpers.Data.Data.MemberDetails.email, Helpers.Data.Data.MemberDetails.companyid);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    var PurchaseItems = JsonConvert.DeserializeObject<List<PurchaseItem>>(json);
                    if (PurchaseItems.Count == 0 || PurchaseItems == null)
                    {
                        PurchaseItems = new List<PurchaseItem>();
                    }
                    Helpers.Data.Data.PurchaseItems = PurchaseItems;
                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public static async Task<bool> LoadMyPoints()
        {
            try
            {

                string url = MyPoints.GenerateMyPointsURL(Helpers.Data.Data.MemberDetails.email, Helpers.Data.Data.MemberDetails.companyid);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    var MyPoints = JsonConvert.DeserializeObject<MyPoints>(json);
                    if (MyPoints == null)
                    {
                        MyPoints = new MyPoints() { details = new List<PointsDetail>() };
                    }
                    Helpers.Data.Data.MyPoints = MyPoints;
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public static async Task<bool> LoadBranchesList()
        {
            try
            {
                String url = Branch.GenerateBranchesURL(Helpers.Data.Data.MemberDetails.companyid);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    var BranchesList = JsonConvert.DeserializeObject<List<Branch>>(json);
                    if (BranchesList.Count == 0 || BranchesList == null)
                    {
                        BranchesList = new List<Branch>();
                    }
                    Helpers.Data.Data.BranchesList = BranchesList;
                    return true;
                }

            }
            catch (Exception e) { return false; }
        }

        public static async Task<bool> LoadPromotions()
        {
            try
            {
                string url = KKSuperMart.Models.Promotions.GeneratePromotionsURL(Helpers.Data.Constants.CompanyId);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    var Promotions = JsonConvert.DeserializeObject<List<Promotions>>(json);
                    if (Promotions.Count == 0 || Promotions == null)
                    {
                        Promotions = new List<Promotions>();
                    }
                    Helpers.Data.Data.Promotions = Promotions;
                    return true;
                }

            }
            catch (Exception e)
            { return false; }

        }

        public static async Task<bool> LoadCoupons()
        {
            try
            {
                String url = Coupon.GenerateCouponsURL(Helpers.Data.Data.MemberDetails.email, Helpers.Data.Data.MemberDetails.companyid);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    var Coupons = JsonConvert.DeserializeObject<List<Coupon>>(json);
                    if (Coupons.Count == 0 || Coupons == null)
                    {
                        Coupons = new List<Coupon>();
                    }
                    Helpers.Data.Data.Coupons = Coupons;
                    return true;

                }
            }
            catch (Exception e) { return false; }
        }

        public static async Task<bool> LoadTeamMembers()
        {
            try
            {
                string url = TeamMember.GenerateTeamMembersURL(Helpers.Data.Data.MemberDetails.companyid);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    var TeamMembers = JsonConvert.DeserializeObject<List<TeamMember>>(json);
                    Helpers.Data.Data.TeamMembers = TeamMembers;
                    return true;
                }
            }
            catch (Exception e) { return false; }



        }


    }
}
