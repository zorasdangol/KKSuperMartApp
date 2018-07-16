using System;
using System.Collections.Generic;
using System.Net.Http;
using KKSuperMart.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace KKSuperMart.Views
{
    public partial class ContactUsPage : ContentPage
    {
        private Contact _Contact;
        public Contact Contact 
        { 
            get { return _Contact; }
            set { _Contact = value; OnPropertyChanged("Contact"); } 
        } 

        public ContactUsPage()
        {
            InitializeComponent();
            LoadContact();


        }

        public async void LoadContact(){
            try
            {
                String url = Contact.GenerateContactURL(Helpers.Data.Data.MemberDetails.companyid);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    Contact = JsonConvert.DeserializeObject<Contact>(json);
                    Helpers.Data.Data.Contact = Contact;
                    this.CompanyName.Text = Contact.COMPANYNAME;
                    this.Address.Text = Contact.CADDRESS;
                    this.Phone.Text = Contact.CONTACTNO;
                    this.Email.Text = Contact.EMAIL;
                    this.Website.Text = Contact.WEBADDRESS;
                }
            }
            catch (Exception e) { await App.Current.MainPage.DisplayAlert("Error", "Cannot connect to server", "Ok"); }
       
        }
    }
}
