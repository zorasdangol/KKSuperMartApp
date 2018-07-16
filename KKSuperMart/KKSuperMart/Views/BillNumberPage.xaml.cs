using System;
using System.Collections.Generic;
using KKSuperMart.Models;
using KKSuperMart.ViewModels;
using Xamarin.Forms;

namespace KKSuperMart.Views
{
    public partial class BillNumberPage : ContentPage
    {
        public BillNumberPageVM viewModel { get; set; }
        public BillNumberPage()
        {
            BindingContext = viewModel = new BillNumberPageVM();
            InitializeComponent();
        }
    }
}
