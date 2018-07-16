using System;
using System.Collections.Generic;
using KKSuperMart.Models;
using KKSuperMart.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace KKSuperMart.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPageVM viewModel { get; set; }
        public MapPage()
        {
            try
            {
                InitializeComponent();
                BindingContext = viewModel = new MapPageVM();
                var latitude = Convert.ToDouble(Helpers.Data.Data.SelectedBranch.LATITUDE);
                var longitude = Convert.ToDouble(Helpers.Data.Data.SelectedBranch.LONGITUDE);
                var branchName = Helpers.Data.Data.SelectedBranch.NAME;
                var address = Helpers.Data.Data.SelectedBranch.ADDRESS;


                var pin = new Pin
                {
                    Type = PinType.Generic,
                    Position = new Position(latitude, longitude),
                    Label = branchName,
                    Address = address,
                };

                BranchMap.MoveToRegion(new Xamarin.Forms.Maps.MapSpan(new Xamarin.Forms.Maps.Position(latitude, longitude), 0.010, 0.010));
                BranchMap.Pins.Add(pin);
            }
            catch (Exception e){ App.Current.MainPage.DisplayAlert("Error", "Map error", "Cancel"); }
        }

    }
}
