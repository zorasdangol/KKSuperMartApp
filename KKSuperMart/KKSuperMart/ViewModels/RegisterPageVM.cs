using System;
using System.Net.Http;
using System.Text;
using KKSuperMart.Models;
using KKSuperMart.Views;
using Newtonsoft.Json;
using Xamarin.Forms;
using KKSuperMart;

namespace KKSuperMart.ViewModels
{
    public class RegisterPageVM:BaseViewModel
    {
        private MemberDetails _MemberDetails;
        public MemberDetails MemberDetails
        {
            get { return _MemberDetails; }
            set { _MemberDetails = value; OnPropertyChanged("MemberDetails"); }
        } 

        public Command SubmitCommand { get; set; }
        public Command BackCommand { get; set; }

        public RegisterPageVM()
        {
            MemberDetails = new MemberDetails();
            SubmitCommand = new Command(ExecuteSubmitCommand) ;
            BackCommand = new Command(ExecuteBackCommand);
        }

        public async void ExecuteBackCommand()
        {
            try
            {
                await App.Current.MainPage.Navigation.PopModalAsync();
            }
            catch { }
        }


        public async void ExecuteSubmitCommand(){
            try
            {                
                MemberDetails.companyid = Helpers.Data.Constants.CompanyId;

                var functionresponse = MemberDetailsValidation.ValidateMemberDetails(MemberDetails);
                if (functionresponse.Status == "error")
                {
                    await App.Current.MainPage.DisplayAlert("Error", functionresponse.Message, "Cancel");
                }
                else
                {
                    String url = MemberDetails.GenerateSignInURL(MemberDetails.email, MemberDetails.mob, MemberDetails.companyid);
                    string ContentType = "application/json"; // or application/xml

                    var JObject = JsonConvert.SerializeObject(MemberDetails);
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.PostAsync(url, new StringContent(JObject.ToString(), Encoding.UTF8, ContentType));
                        var json = await response.Content.ReadAsStringAsync();
                        SignInResponse result = JsonConvert.DeserializeObject<SignInResponse>(json);
                        if (result.status == "ok")
                        {
                            Helpers.Data.Data.MemberDetails = MemberDetails;
                            Helpers.Data.Data.Mode = "register";
                            await App.Current.MainPage.Navigation.PushModalAsync(new OTPPage());
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Error", result.result, "Cancel");
                        }
                    }
                }
            }
            catch (Exception e) { await App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server:\n" + e.Message, "Ok"); }
                  
           
        }
    }
}
