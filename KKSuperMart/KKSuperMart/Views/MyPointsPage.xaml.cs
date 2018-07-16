using System;
using System.Collections.Generic;
using KKSuperMart.ViewModels;
using Xamarin.Forms;

namespace KKSuperMart.Views
{
    public partial class MyPointsPage : ContentPage
    {
        public MyPointsPageVM viewModel { get; set; }
        public MyPointsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MyPointsPageVM();
        }
    }
}
