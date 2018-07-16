using System;
using Android.App;
using Android.Content;
using KKSuperMart.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using System.ComponentModel;
using Android.Widget;
using KKSuperMart.Views;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationRenderer))]
namespace KKSuperMart.Droid.Renderers
{
    public class CustomNavigationRenderer : NavigationPageRenderer
    {
        public CustomNavigationRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals("CurrentPage"))
                // If we're on MainPage show the icon, otherwise hide it
                //bool visible = (Element.CurrentPage is MainHomePage);
                ChangeToolbarIconVisibility(Element.CurrentPage is MainHomePage);
        }

        private void ChangeToolbarIconVisibility(bool visible)
        {
            ImageView toolbarIcon = FindViewById<ImageView>(Resource.Id.toolbarIcon);  
            toolbarIcon.Visibility = visible ? Android.Views.ViewStates.Visible : Android.Views.ViewStates.Gone;
        }

   
        //protected virtual void SetupPageTransition(FragmentTransaction transaction, bool isPush)
        //{
        //    if (isPush)
        //        transaction.SetTransition((int)FragmentTransit.FragmentOpen);
        //    else
        //        transaction.SetTransition((int)FragmentTransit.FragmentClose);
        //}

    }
}