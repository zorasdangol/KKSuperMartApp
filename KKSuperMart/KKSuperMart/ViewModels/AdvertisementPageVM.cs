using System;
using System.Collections.Generic;
using System.Net.Http;
using KKSuperMart.Models;
using KKSuperMart.Services;
using KKSuperMart.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace KKSuperMart.ViewModels
{
    public class AdvertisementPageVM : BaseViewModel
    {
        private List<Advertisement> _Advertisements;
        public List<Advertisement> Advertisements
        {
            get { return _Advertisements; }
            set
            {
                _Advertisements = value;
                OnPropertyChanged("Advertisements");
            }
        }

        public Command AdClicked { get; set; }

        public AdvertisementPageVM()
        {
            try
            {
                Advertisements = new List<Advertisement>();
                AdClicked = new Command<string>(ExecuteAdClicked);
                if (Helpers.Data.Data.Advertisements == null || Helpers.Data.Data.Advertisements.Count == 0)
                {
                    LoadAdvertisements();

                }
                else
                {
                    Advertisements = Helpers.Data.Data.Advertisements;
                }
            }
            catch { }
        }

        public void ExecuteAdClicked(string url)
        {
            try
            {
                Device.OpenUri(new Uri("http://" + url));
            }
            catch { }
        }

        public async void LoadAdvertisements()
        {
            try
            {
                bool result =  await ApiConnections.LoadAdvertisements();
                if (result)
                {
                    Advertisements = Helpers.Data.Data.Advertisements;
                }
                else
                {
                    if (Helpers.Data.Data.Advertisements == null || Helpers.Data.Data.Advertisements.Count == 0)
                    {
                        Advertisements = new List<Advertisement>();
                    }
                    else
                    {
                        Advertisements = Helpers.Data.Data.Advertisements;
                    }   
                }              
                
            }catch(Exception e) 
            { 
                await  App.Current.MainPage.DisplayAlert("Error","Cannot Connect to Server:\n"+ e.Message ,"Ok");
              
            }
           
            
        }
    }
}

