using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using KKSuperMart.Models;
using KKSuperMart.Views;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Forms;
using KKSuperMart.Services;

namespace KKSuperMart.ViewModels
{
    public class LoginPageVM : BaseViewModel
    {
            
        private MemberDetails _MemberDetails;
        public MemberDetails MemberDetails
        {
            get { return _MemberDetails; }
            set { _MemberDetails = value; OnPropertyChanged("MemberDetails"); }
        } 

        private DeviceToken _DeviceToken;
        public DeviceToken DeviceToken
        {
            get { return _DeviceToken; }
            set { _DeviceToken = value; OnPropertyChanged("DeviceToken"); }
        }

        private bool _IsLoading;
        public bool IsLoading
        {
            get { return _IsLoading; }
            set { _IsLoading = value; OnPropertyChanged("IsLoading"); }
        }
        
        public Command SignInCommand { get; set; }
        public Command RegisterCommand { get; set; }
		public Command ReSendCommand { get; set; }
		public Command ConfirmCommand { get; set; }
        public Command BackCommand { get; set; }

        public LoginPageVM()
        {
            MemberDetails = new MemberDetails();
            DeviceToken = new DeviceToken();

            SignInCommand = new Command( () =>  ExecuteSignInCommand());
            RegisterCommand = new Command(() => ExecuteRegisterCommand());
            ReSendCommand = new Command(() => ExecuteReSendCommand());
            ConfirmCommand = new Command(() => ExecuteConfirmCommand());
			BackCommand = new Command(() => ExecuteBackCommand());
            IsLoading = false;

        }

		public async void ExecuteBackCommand(){
			await App.Current.MainPage.Navigation.PopModalAsync();
            IsLoading = false;
		}
       

        public async void ExecuteSignInCommand()
        {
            try
            {
                IsLoading = true;
                MemberDetails.companyid = Helpers.Data.Constants.CompanyId;

                await LoginApiConnections.SignIn(MemberDetails);
                //IsLoading = false;
                
            }
            catch (Exception e) { await App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server:\n" + e.Message, "Ok"); }        
        } 

        public async void ExecuteReSendCommand()
        {
            try
            {
                Helpers.Data.Data.MemberDetails.companyid = Helpers.Data.Constants.CompanyId;
                MemberDetails = Helpers.Data.Data.MemberDetails;

                await LoginApiConnections.ReSend(MemberDetails);              
                
            }catch(Exception e) { await  App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server", "Ok"); }
                    
        } 

        public async void ExecuteConfirmCommand(){
            try
            {                
                DeviceToken.email = Helpers.Data.Data.MemberDetails.email;
                DeviceToken.mobile = Helpers.Data.Data.MemberDetails.mob;
			    DeviceToken.deviceToken = Helpers.Data.Data.DeviceToken;
                //DeviceToken.deviceToken = Helpers.Data.Data.DeviceToken ="sarojDemoDeviceToken"+new Random().Next() ;
                DeviceToken.companyid = Helpers.Data.Data.MemberDetails.companyid;
                DeviceToken.mode = Helpers.Data.Data.Mode;

                await LoginApiConnections.Confirm(DeviceToken);  
            }catch(Exception e) {
                await  App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server:\n" + e.Message,"Ok"); }   
        }

        public void ExecuteRegisterCommand()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new RegisterPage());
        }

    }
}

