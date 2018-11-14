using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Plugin.FirebasePushNotification;

namespace KKSuperMart.Droid
{
	[Activity (Label = "KKSuperMart", Icon = "@drawable/icon",Theme ="@style/MainTheme",  ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
            TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate (bundle);
            
            Rg.Plugins.Popup.Popup.Init(this, bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Xamarin.FormsMaps.Init(this, bundle);

            string dbName = "KKSuperMart.sqlite";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string fullPath = Path.Combine(folderPath, dbName);

            LoadApplication(new App(fullPath));
            //FirebasePushNotificationManager.ProcessIntent(Intent);
        }

    }
}

