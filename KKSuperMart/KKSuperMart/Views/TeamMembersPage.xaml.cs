using System;
using System.Collections.Generic;
using KKSuperMart.ViewModels;

using Xamarin.Forms;

namespace KKSuperMart.Views
{
    public partial class TeamMembersPage : ContentPage
    {
        public TeamMembersPageVM viewModel { get; set; }
        public TeamMembersPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new TeamMembersPageVM();
        }
    }
}
