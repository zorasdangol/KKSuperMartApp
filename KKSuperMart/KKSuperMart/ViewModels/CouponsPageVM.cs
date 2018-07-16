using System;
using System.Collections.Generic;
using System.Net.Http;
using KKSuperMart.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using KKSuperMart.Views;
using Rg.Plugins.Popup.Extensions;
using KKSuperMart.Services;

namespace KKSuperMart.ViewModels
{
    public class CouponsPageVM:BaseViewModel
    {
        private List<Coupon> _Coupons;
        public List<Coupon> Coupons
        {
            get { return _Coupons; }
            set { _Coupons = value; OnPropertyChanged("Coupons"); }
        }

        private bool _IsQRVisible;
        public bool IsQRVisible 
        {
            get { return _IsQRVisible; }
            set { _IsQRVisible = value; OnPropertyChanged("IsQRVisible"); }
            
        }

        private int _ItemCount;
        public int ItemCount
        {
            get { return _ItemCount; }
            set { _ItemCount = value; OnPropertyChanged("ItemCount"); }
        }

        public CouponsPageVM()
        {
            Coupons = new List<Coupon>();
            LoadCoupons();
            ItemCount = Coupons.Count;
            IsQRVisible = false;
        }

        public async void LoadCoupons()
        {
            try
            {
                bool result = await ApiConnections.LoadCoupons();
                if (result)
                {
                    Coupons = Helpers.Data.Data.Coupons;
                    ItemCount = Coupons.Count;
                }
                else
                {
                    if (Helpers.Data.Data.Coupons == null || Helpers.Data.Data.Coupons.Count == 0)
                    {
                        Coupons = new List<Coupon>();
                        ItemCount = Coupons.Count;
                    }
                    else
                    {
                        Coupons = Helpers.Data.Data.Coupons;
                        ItemCount = Coupons.Count;
                    }
                    await App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server", "Ok");                    
                }                
            }
            catch (Exception e) { await App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server", "Ok"); }
        }

        public async void NavigateToQRCodePage()
        {
            try
            {
                Helpers.Data.Data.QRURL = Helpers.Data.Data.SelectedCoupon.QRCodeImagePath;
                await App.Current.MainPage.Navigation.PushPopupAsync(new QRPopupPage());
                Helpers.Data.Data.SelectedCoupon = new Coupon();
            }
            catch { }
        }

    }
}

