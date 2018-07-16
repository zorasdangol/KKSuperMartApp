using System;

using Android.App;
using Android.OS;
using Android.Runtime;
//using Firebase;
using Plugin.CurrentActivity;
using Plugin.FirebasePushNotification;

namespace KKSuperMart.Droid
{
    //You can specify additional application information in this attribute
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
             
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          :base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            try
            {

                base.OnCreate();
                var str = Helpers.Data.Data.MemberDetails;
                //If debug you should reset the token each time.
                #if DEBUG
                //FirebasePushNotificationManager.Initialize(this, true);
                #else
                //FirebasePushNotificationManager.Initialize(this,false);
                #endif

                //Handle notification when app is closed here

                CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
                {
                    
                };
            }catch(Exception e)
            {

            }
            

           

            //FirebasePushNotificationManager.NotificationContentTitleKey = "KK Super Mart";
            RegisterActivityLifecycleCallbacks(this);

        }

             
        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {
        }

    }
}