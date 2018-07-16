using System;
using System.Collections.Generic;
using System.Net.Http;
using KKSuperMart.Models;
using KKSuperMart.Views;
using Newtonsoft.Json;
using Xamarin.Forms;
using KKSuperMart.Services;

namespace KKSuperMart.ViewModels
{
    public class BranchesPageVM:BaseViewModel
    {
        private List<Branch> _BranchesList;
        public List<Branch> BranchesList
        {
            get { return _BranchesList; }
            set{
                _BranchesList = value; OnPropertyChanged("BranchesList");
            }
        }

        public Command ContactCommand { get; set; }

        public BranchesPageVM()
        {
            BranchesList = new List<Branch>();
            ContactCommand = new Command<string>(ExecuteContactCommand);
            LoadBranchesList();   
        }


        public async void LoadBranchesList()
        {
            try
            {
                bool result = await ApiConnections.LoadBranchesList();
                if (result)
                {
                    BranchesList = Helpers.Data.Data.BranchesList;
                }
                else
                {
                    if (Helpers.Data.Data.BranchesList == null || Helpers.Data.Data.BranchesList.Count == 0)
                    {
                        BranchesList = new List<Branch>();
                    }
                    else
                    {
                        BranchesList = Helpers.Data.Data.BranchesList;
                    }
                    await App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server", "Ok");                   
                }
            }
            catch (Exception e) { await App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server:\n" + e.Message, "Ok"); }
        }

        public async void NavigateToMap()
        {
            await (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new MapPage());

        }

        public void ExecuteContactCommand(string value)
        {
            Device.OpenUri(new Uri("tel:"+value));
        }
    }
}
