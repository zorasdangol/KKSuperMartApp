using System;
using System.Linq;
using KKSuperMart.Models;
using KKSuperMart.Views;
using Plugin.FirebasePushNotification;

using SQLite;
using Xamarin.Forms;

namespace KKSuperMart
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();

        }
        public App(string databaseLocation)
        {
            try
            {
                DatabaseLocation = databaseLocation;
                InitializeComponent();

                //CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
                //         {
                //         };

                CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
                {
                    Helpers.Data.Data.DeviceToken = p.Token;
                };

                CheckLoggedInUser();
            }
            catch { }
        }

        public void CheckLoggedInUser()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<UserDetails>();
                    var rows = conn.Table<UserDetails>().ToList();

                    if (rows.Count > 0 && rows.FirstOrDefault().email != null)
                    {
                        var UserDetails = rows.FirstOrDefault();
                        Helpers.Data.Data.MemberDetails = new MemberDetails()
                        {
                            memid = UserDetails.email,
                            email = UserDetails.email,
                            companyid = UserDetails.companyid,
                            mob = UserDetails.mob,
                            fname = UserDetails.fname,
                            lname = UserDetails.lname,
                            dob = UserDetails.dob,
                            sex = UserDetails.sex,
                            QRCodePath = UserDetails.QRCodePath,
                            add = new addredd_detail()
                            {
                                hno = UserDetails.hno,
                                dist = UserDetails.dist,
                                street = UserDetails.street,
                                tole = UserDetails.tole,
                                zone = UserDetails.zone
                            }
                        };
                        App.Current.MainPage = new MasterPage();
                    }
                    else{
                        App.Current.MainPage = new LoginPage();
                    }
                }
            }
            catch (Exception e)
            {
                App.Current.MainPage.DisplayAlert("Error", "Cannot connect to server::\n" + e.Message, "Ok");
            }
        }

      
        protected override void OnStart()
		{
			         
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
