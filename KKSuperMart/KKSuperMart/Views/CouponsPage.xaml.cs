using System;
using System.Collections.Generic;
using KKSuperMart.Models;
using KKSuperMart.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;

namespace KKSuperMart.Views
{
    //public partial class CouponsPage : PopupPage
    public partial class CouponsPage : ContentPage
    {
        public CouponsPageVM viewModel { get; set; }
        public CouponsPage()
        {
            BindingContext = viewModel = new CouponsPageVM();
            InitializeComponent();
        }

		protected  override bool OnBackButtonPressed()
		{
            return base.OnBackButtonPressed();
		}

		void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            try
            {
                if (e.SelectedItem == null)
                {
                    return;
                }
                var listView = sender as ListView;

                Coupon item = e.SelectedItem as Coupon;

                Helpers.Data.Data.SelectedCoupon = item;
                Helpers.Data.Data.QRURL = item.QRCodeImagePath;
                //viewModel.QRImagePath = Helpers.Data.Data.SelectedCoupon.QRCodeImagePath;
                //viewModel.IsQRVisible = true;
                viewModel.NavigateToQRCodePage();
                listView.SelectedItem = null;
            }
            catch { }
        }
    }
}
