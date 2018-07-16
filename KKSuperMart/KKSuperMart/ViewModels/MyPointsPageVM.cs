using System;
using System.Collections.Generic;
using System.Net.Http;
using KKSuperMart.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using KKSuperMart.Services;

namespace KKSuperMart.ViewModels
{
    public class MyPointsPageVM:BaseViewModel
    {
        private MyPoints _MyPoints;
        public MyPoints MyPoints
        {
            get { return _MyPoints; }
            set { _MyPoints = value; OnPropertyChanged("MyPoints"); }    
        }

        private int _ItemCount;
        public int ItemCount
        {
            get { return _ItemCount; }
            set { _ItemCount = value; OnPropertyChanged("ItemCount"); }
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public Command RefreshCommand { get; set; }


        public MyPointsPageVM()
        {
            try
            {
                MyPoints = new MyPoints() { details = new List<PointsDetail>() };
                LoadMyPoints();
                RefreshCommand = new Command(() => ExecuteRefreshCommand());
                ItemCount = MyPoints.details.Count;
            }
            catch { }
        }

        public void ExecuteRefreshCommand()
        {
            IsRefreshing = true;
            LoadMyPoints();
            IsRefreshing = false;
        }

        private async void LoadMyPoints()
        {
            try{
                bool result = await ApiConnections.LoadMyPoints();
                if (result)
                {
                    MyPoints = Helpers.Data.Data.MyPoints;
                    ItemCount = MyPoints.details.Count;
                }
                else
                {
                    if (Helpers.Data.Data.MyPoints == null )
                    {
                        MyPoints = new MyPoints() { details = new List<PointsDetail>() };
                        ItemCount = MyPoints.details.Count;
                    }
                    else
                    {
                        MyPoints = Helpers.Data.Data.MyPoints;
                        ItemCount = MyPoints.details.Count;
                    }
                    await App.Current.MainPage.DisplayAlert("Error", "Cannot connect to server", "Ok");                    
                }
                              
            }catch(Exception e)
            { await App.Current.MainPage.DisplayAlert("Error", "Cannot connect to server:\n" + e.Message, "Ok");}
           
        }
    }
}
