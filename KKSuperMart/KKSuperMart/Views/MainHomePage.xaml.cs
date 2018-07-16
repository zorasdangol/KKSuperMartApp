using System;
using System.Collections.Generic;
using KKSuperMart.Models;
using KKSuperMart.ViewModels;
using Xamarin.Forms;

namespace KKSuperMart.Views
{
    public partial class MainHomePage : ContentPage
    {
        public MainHomePageVM viewModel { get; set; }
        public MainHomePage()
        {
            try
            {
                Helpers.Data.Data.SelectedMenu = new MenuItems();
                NavigationPage.SetBackButtonTitle(this, "");
                NavigationPage.SetTitleIcon(this, "titleIcon.png");

                InitializeComponent();
                BindingContext = viewModel = new MainHomePageVM();
                var image = new Image();
            }
            catch { }         
        }
        
    }
}
