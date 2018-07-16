using System;
using System.Collections.Generic;
using System.Text;
using KKSuperMart.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using KKSuperMart.Views;
using SQLite;

namespace KKSuperMart.Services
{
    class LoginApiConnections
    {
        public async static Task SignIn(MemberDetails MemberDetails)
        {
            try
            {
                String url = MemberDetails.GenerateSignInURL(MemberDetails.email, MemberDetails.mob, MemberDetails.companyid);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    SignInResponse result = JsonConvert.DeserializeObject<SignInResponse>(json);
                    if (result.status == "ok")
                    {
                        Helpers.Data.Data.MemberDetails = MemberDetails = JsonConvert.DeserializeObject<MemberDetails>(result.result);
                        Helpers.Data.Data.MemberDetails.companyid = MemberDetails.companyid = Helpers.Data.Constants.CompanyId;

                        Helpers.Data.Data.Mode = "login";
                        await App.Current.MainPage.Navigation.PushModalAsync(new OTPPage());
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Cannot connect Find member", "Cancel");
                    }
                }
            }
            catch (Exception e) { await App.Current.MainPage.DisplayAlert("Error", "Cannot connect to server", "Ok"); }
        }

        public async static Task ReSend(MemberDetails MemberDetails)
        {
            try
            {
                String url = MemberDetails.GenerateSignInURL(MemberDetails.email, MemberDetails.mob, MemberDetails.companyid);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    SignInResponse result = JsonConvert.DeserializeObject<SignInResponse>(json);
                    if (result.status == "ok")
                    {
                        await App.Current.MainPage.DisplayAlert("Success", "Send Sucessfully,Please,Check Phone!", "Ok");
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Cannot connect Find member", "Cancel");
                    }
                }
            }
            catch (Exception e) { await App.Current.MainPage.DisplayAlert("Error", "Cannot connect to server", "Ok"); }
        }

        public async static Task Confirm(DeviceToken DeviceToken)
        {
            try
            {
                var JsonObject = JsonConvert.SerializeObject(DeviceToken);
                string ContentType = "application/json"; // or application/xml
                String url = Helpers.Data.Constants.DeviceTokenUrl;
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsync(url, new StringContent(JsonObject.ToString(), Encoding.UTF8, ContentType));
                    var json = await response.Content.ReadAsStringAsync();
                    SignInResponse result = JsonConvert.DeserializeObject<SignInResponse>(json);
                    if (result.status == "ok" || (result.status == "error" && result.result == "Duplicate Token"))
                    {
                        using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                        {
                            conn.DeleteAll<UserDetails>();
                            UserDetails userDetails = new UserDetails()
                            {
                                memid = Helpers.Data.Data.MemberDetails.email,
                                email = Helpers.Data.Data.MemberDetails.email,
                                companyid = Helpers.Data.Data.MemberDetails.companyid,
                                mob = Helpers.Data.Data.MemberDetails.mob,
                                fname = Helpers.Data.Data.MemberDetails.fname,
                                lname = Helpers.Data.Data.MemberDetails.lname,
                                dob = Helpers.Data.Data.MemberDetails.dob,
                                sex = Helpers.Data.Data.MemberDetails.sex,
                                QRCodePath = Helpers.Data.Data.MemberDetails.QRCodePath,
                                DeviceToken = Helpers.Data.Data.DeviceToken,
                                dist = Helpers.Data.Data.MemberDetails.add.dist,
                                hno = Helpers.Data.Data.MemberDetails.add.hno,
                                tole = Helpers.Data.Data.MemberDetails.add.tole,
                                street = Helpers.Data.Data.MemberDetails.add.street,
                                zone = Helpers.Data.Data.MemberDetails.add.zone
                            };
                            conn.Insert(userDetails);
                            App.Current.MainPage = new MasterPage();
                        }
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", result.result, "Cancel");
                    }
                }
            }
            catch (Exception e) { await App.Current.MainPage.DisplayAlert("Error", "Cannot connect to server", "Ok"); }
        
        }
    }
}
