using System;
using System.Collections.Generic;
using KKSuperMart.Models;
using KKSuperMart.ViewModels;
using Xamarin.Forms;

namespace KKSuperMart.Views
{
    public partial class BranchesPage : ContentPage
    {
        public BranchesPageVM viewModel { get; set; }

        public BranchesPage()
        {
            NavigationPage.SetTitleIcon(this, "");
            //NavigationPage.SetHasNavigationBar(this,false);
            InitializeComponent();
            BindingContext = viewModel = new BranchesPageVM();
        }

        void Branch_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var listView = sender as ListView;
                Branch item = e.SelectedItem as Branch;
                Helpers.Data.Data.SelectedBranch = item;
                viewModel.NavigateToMap();
            }
            catch { }
            
        }
    }
}
