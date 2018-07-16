using System;
using System.Collections.Generic;
using KKSuperMart.Models;
using KKSuperMart.ViewModels;
using Xamarin.Forms;

namespace KKSuperMart.Views
{
    public partial class PurchaseListPage :ContentPage

    {
        public PurchaseListPageVM viewModel { get; set; }

        public PurchaseListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PurchaseListPageVM();
            NavigationPage.SetBackButtonTitle(this, "");
        }

        void PurchaseItem_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var listView = sender as ListView;
                if (listView.SelectedItem != null)
                {
                    PurchaseItem item = e.SelectedItem as PurchaseItem;
                    Helpers.Data.Data.SelectedPurchaseItem = item;
                    listView.SelectedItem = null;
                    viewModel.NavigateToBillNumber();
                }
            }
            catch 
            {

            }
        }

       


    }
}
