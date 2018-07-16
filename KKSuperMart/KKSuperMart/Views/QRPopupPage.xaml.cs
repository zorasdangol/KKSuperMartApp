using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions ;

using Xamarin.Forms;

namespace KKSuperMart.Views
{
    public partial class QRPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        public QRPopupPage()
        {
            InitializeComponent();
            try
            {
                if (Helpers.Data.Data.QRURL != null)
                    QRURL.Uri = new Uri(Helpers.Data.Data.QRURL);
            }
            catch { }
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                await App.Current.MainPage.Navigation.PopPopupAsync();
            }
            catch { }
        }

		protected override bool OnBackButtonPressed()
		{
            return base.OnBackButtonPressed();
		}		
	}
}
