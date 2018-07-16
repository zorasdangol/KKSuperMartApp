using System;
using System.Collections.Generic;
using KKSuperMart.ViewModels;
using Xamarin.Forms;

namespace KKSuperMart.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPageVM viewModel { get; set; }
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new RegisterPageVM();
           
        }
    }
}
