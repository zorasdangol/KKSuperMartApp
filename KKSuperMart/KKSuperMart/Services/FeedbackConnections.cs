using KKSuperMart.Models;
using KKSuperMart.Views;
using Newtonsoft.Json;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KKSuperMart.Services
{
    public class FeedbackConnections
    {
        public FeedbackConnections()
        {
        }

        public static async Task FeedbackSubmit(Feedback Feedback)
        {
            try
            {
                var url = Helpers.Data.Constants.FeedbackUrl;
                var JsonObject = JsonConvert.SerializeObject(Feedback);
                string ContentType = "application/json"; // or application/xml

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.PostAsync(url, new StringContent(JsonObject.ToString(), Encoding.UTF8, ContentType));

                    var result = response.Content.ReadAsStringAsync().Result;

                    if (result == "true")
                    {
                        (App.Current.MainPage as MasterDetailPage).Detail = new NavigationPage(new MainHomePage());
                        await App.Current.MainPage.DisplayAlert("Success", "Successfully Uploaded your feedback", "Ok");
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Error", "Cannot Upload your feedback", "Ok");

                }

            }catch(Exception e) { await App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server", "Ok"); }

        }

        public async static Task<bool> LoadQueries()
        {
            try
            {
                String url = Message.GenerateChatURL(Helpers.Data.Data.MemberDetails.email, Helpers.Data.Data.MemberDetails.companyid);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    var ChatMessages = JsonConvert.DeserializeObject<List<Message>>(json);
                    Helpers.Data.Data.ChatMessages = ChatMessages;
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;               
            }
        }

        public static async Task InquirySubmit(Feedback Feedback )
        {

            try
            {
                var url = Helpers.Data.Constants.InquiryUrl;
                var file = Helpers.Data.Data.QueryImage;
                byte[] upfilebytes;

                //read file into upfilebytes array

                if (file != null)
                    upfilebytes = File.ReadAllBytes(file.Path);
                else
                {
                    if(Feedback.MESSAGE == "")
                    {
                        await App.Current.MainPage.DisplayAlert("Info", "Empty Query. Please Select image or write something.", "Ok");
                        return;
                    }
                    else
                        upfilebytes = new byte[10];


                }
                //create new HttpClient and MultipartFormDataContent and add our file, and StudentId
                HttpClient client = new HttpClient();
                //MultipartContent content = new MultipartContent();
                MultipartFormDataContent content = new MultipartFormDataContent();
                ByteArrayContent baContent = new ByteArrayContent(upfilebytes);

                StringContent MessageContent = new StringContent(Feedback.MESSAGE);
                StringContent CompanyIdContent = new StringContent(Feedback.COMPANYID);
                StringContent MemberIdContent = new StringContent(Feedback.MEMBERID);

                content.Add(baContent, "ImageUpload", "Test.jpg");
                content.Add(MessageContent, "MESSAGE");
                content.Add(CompanyIdContent, "COMPANYID");
                content.Add(MemberIdContent, "MEMBERID");


                //upload MultipartFormDataContent content async and store response in response var
                var response = await client.PostAsync(url, content);
                var result = response.Content.ReadAsStringAsync().Result;

                if (result == "true")
                {
                    (App.Current.MainPage as MasterDetailPage).Detail = new NavigationPage(new MainHomePage());
                    await App.Current.MainPage.DisplayAlert("Success", "Successfully Uploaded your Query", "Ok");
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error", "Image cannot be Uploaded:\n" + result, "Ok");

            }
            catch (Exception ex) { await App.Current.MainPage.DisplayAlert("Error", "Cannot Upload Image:\n" + ex.Message, "Cancel"); }
        }

    }

}
