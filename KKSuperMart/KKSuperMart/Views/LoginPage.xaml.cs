using System;
using System.Collections.Generic;
using KKSuperMart.ViewModels;
using Xamarin.Forms;

namespace KKSuperMart.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPageVM viewModel { get; set; }
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LoginPageVM();

            //var assembly = typeof(LoginPage);
        }
    }
}
