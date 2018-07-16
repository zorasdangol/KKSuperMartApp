using System;
using System.Collections.Generic;
using KKSuperMart.ViewModels;
using Xamarin.Forms;

namespace KKSuperMart.Views
{
    public partial class OTPPage : ContentPage
    {
        public LoginPageVM viewModel { get; set; }
        public OTPPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LoginPageVM();
        }
    }
}
