using KKSuperMart.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KKSuperMart.ViewModels
{
    public class MyProfilePageVM:BaseViewModel
    {
        private MemberDetails _MemberDetails;
        public MemberDetails MemberDetails
        {
            get { return _MemberDetails; }
            set { _MemberDetails = value; OnPropertyChanged("MemberDetails"); }
        }

        public Command SubmitCommand { get; set; }
        public Command BackCommand { get; set; }

        public MyProfilePageVM()
        {
            SubmitCommand = new Command(() => ExecuteConfirmCommand());
            BackCommand = new Command(() => ExecuteBackCommand());
        }

        public async void ExecuteBackCommand()
        {
            try
            {
                await (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PopAsync();
            }
            catch { }
        }

        public void ExecuteConfirmCommand()
        {
            Helpers.Data.Data.MemberDetails = MemberDetails;
        }
    }
}
