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
    public class PurchaseListPageVM:BaseViewModel
    {
        private List<PurchaseItem> _PurchaseItems;
        public List<PurchaseItem> PurchaseItems
        { 
            get { return _PurchaseItems; } 
            set { _PurchaseItems = value; OnPropertyChanged("PurchaseItems"); } 
        }

        private int _ItemCount;
        public int ItemCount
        {
            get { return _ItemCount; }
            set { _ItemCount = value; OnPropertyChanged("ItemCount"); }
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

        public Command RefreshCommand { get; set; }

        public PurchaseListPageVM()
        {
            PurchaseItems = new List<PurchaseItem>();
            LoadPurchaseList();
            RefreshCommand = new Command(() => ExecuteRefreshCommand());
            ItemCount = PurchaseItems.Count;
        }

        public  void ExecuteRefreshCommand()
        {
            IsRefreshing = true;
            LoadPurchaseList();
            IsRefreshing = false;
        }

        public async void LoadPurchaseList()
        {
            try
            {

                bool result = await ApiConnections.LoadPurchaseList();
                if (result)
                {
                    PurchaseItems = Helpers.Data.Data.PurchaseItems;
                    ItemCount = PurchaseItems.Count;
                }
                else
                {
                    if (Helpers.Data.Data.PurchaseItems == null || Helpers.Data.Data.PurchaseItems.Count == 0)
                    {
                        PurchaseItems = new List<PurchaseItem>();
                        ItemCount = PurchaseItems.Count;
                    }
                    else
                    {
                        PurchaseItems = Helpers.Data.Data.PurchaseItems;
                        ItemCount = PurchaseItems.Count;                       
                    }
                    await App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server", "Ok");
                }
                
            }
            catch (Exception e)
            { 
                await App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server:\n" + e.Message , "Ok");
            }
           
        }

        public async void NavigateToBillNumber()
        {
            await (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new BillNumberPage());
        }
    }
}
