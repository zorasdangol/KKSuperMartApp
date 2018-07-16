using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KKSuperMart.Models;
using KKSuperMart.Views;
using SQLite;
using Xamarin.Forms;

namespace KKSuperMart.ViewModels
{
    public class MasterPageVM : BaseViewModel
    {
        public List<MenuItems> MenuList { get; set; }

        private MemberDetails _MemberDetails;
        public MemberDetails MemberDetails
        {
            get { return _MemberDetails; }
            set { _MemberDetails = value; OnPropertyChanged("MemberDetails"); }
        }

        private char _FirstLetter;
        public char  FirstLetter
        {
            get { return _FirstLetter; }
            set { _FirstLetter = value; OnPropertyChanged("FirstLetter"); }
        }

        public MasterPageVM()
        {
            try
            {
                MenuList = Helpers.Data.Data.MenuList;
                MemberDetails = Helpers.Data.Data.MemberDetails;
                var word = MemberDetails.fname.ToUpper();
                FirstLetter = word[0];
            }
            catch { }
        }

        public async Task LogOutCheck()
        {
            try
            {
                var res = await App.Current.MainPage.DisplayAlert("Confirm", "Are you sure to LogOut?", "Ok", "Cancel");
                if (res)
                {
                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                        conn.DeleteAll<UserDetails>();
                        App.Current.MainPage = new LoginPage();

                    }
                }
            }
            catch { }
        }
    }
}

