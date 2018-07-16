﻿using KKSuperMart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KKSuperMart.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InquiryHistoryPage : ContentPage
	{
        public InquiryHistoryPageVM viewModel { get; set; }
		public InquiryHistoryPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new InquiryHistoryPageVM();
            
        }
	}
}