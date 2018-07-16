using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using KKSuperMart.Models;
using KKSuperMart.Views;
using Newtonsoft.Json;
using Xamarin.Forms;
using KKSuperMart.Services;

namespace KKSuperMart.ViewModels
{
    public class MainHomePageVM:BaseViewModel
    {
        private List<Product> _ProductList;

        public List<Product> ProductList
        {
            get { return _ProductList; }
            set { _ProductList = value; OnPropertyChanged("ProductList"); }
        }

       
        private List<Promotions> _Promotions;

        public List<Promotions> Promotions
        {
            get { return _Promotions; }
            set { _Promotions = value; OnPropertyChanged("Promotions"); }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public Command PurchaseListCommand { get; set; }

        public Command MyPointsCommand { get; set; }
        public Command CouponsCommand { get; set; }
        public Command RefreshCommand { get; set; }

        public MainHomePageVM()
        {
            try
            {
                ProductList = new List<Product>();
                Promotions = new List<Promotions>();
                PurchaseListCommand = new Command(() => ExecutePurchaseListCommand());
                MyPointsCommand = new Command(() => ExecuteMyPointsCommand());
                CouponsCommand = new Command(() => ExecuteCouponsCommand());
                RefreshCommand = new Command(() => ExecuteRefreshCommand());
                Helpers.Data.Data.SelectedMenu = new MenuItems();
                LoadPromotions();
                new ApiConnections();
            }
            catch { }
        }

        public async void ExecutePurchaseListCommand()
        {
            await (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new PurchaseListPage());
        }
        public async void ExecuteMyPointsCommand()
        {
            await (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new MyPointsPage());
        }
        public async void ExecuteCouponsCommand()
        {
            await (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new CouponsPage());
        }

        public  void ExecuteRefreshCommand()
        {
            IsRefreshing = true;
            LoadPromotions();
            //(App.Current.MainPage as MasterDetailPage).Detail = new NavigationPage(new  MainHomePage());
            IsRefreshing = false;
        }

        public async void LoadPromotions()
        {
            try
            {
                bool result = await ApiConnections.LoadPromotions();
                if (result)
                {
                    Promotions = Helpers.Data.Data.Promotions;
                }
                else
                {
                    if (Helpers.Data.Data.Promotions == null || Helpers.Data.Data.Promotions.Count == 0)
                    {
                        Promotions = new List<Promotions>();
                    }
                    else
                    {
                        Promotions = Helpers.Data.Data.Promotions;
                    }
                    await App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server", "Ok");                    
                }
            }
            catch (Exception e) { await App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server:\n" + e.Message, "Ok"); }
           
        }
    }
}
