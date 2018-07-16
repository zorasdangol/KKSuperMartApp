using System;
using System.Collections.Generic;
using KKSuperMart.ViewModels;
using Xamarin.Forms;

namespace KKSuperMart.Views
{
    public partial class AdvertisementPage :StackLayout
    {
        public AdvertisementPageVM viewModel { get; set; }
        public AdvertisementPage()
        {
            try
            {
                //AdvertisementImage.GestureRecognizers.Add(new TapGestureRecognizer() { Command = viewModel.AdClicked});
                InitializeComponent();
                BindingContext = viewModel = new AdvertisementPageVM();
                if(viewModel.Advertisements != null && viewModel.Advertisements.Count != 0)
                {
                    Device.StartTimer(TimeSpan.FromSeconds(4), (Func<bool>)(() =>
                    {
                        CarouselAdvertisements.Position = (CarouselAdvertisements.Position + 1) % viewModel.Advertisements.Count;

                        return true;
                    }));                    
                }                
            }catch(Exception e)
            {
            }

        }
    }
}
