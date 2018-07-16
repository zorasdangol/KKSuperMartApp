using System;
using System.Collections.Generic;
using KKSuperMart.Models;
using KKSuperMart.ViewModels;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;

namespace KKSuperMart.Views
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPageVM viewModel { get; set; }
        public MasterPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MasterPageVM();
            Detail = new NavigationPage(new MainHomePage());
            NavigationPage.SetBackButtonTitle(this, "");

        }
        public bool IsVisibleMenu = false;

        public async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var listView = sender as ListView;

                if (e.SelectedItem == null)
                {
                    return;
                }

                MenuItems item = e.SelectedItem as MenuItems;
                if (Helpers.Data.Data.SelectedMenu != item)
                {
                    Helpers.Data.Data.SelectedMenu = item;
                    switch (item.Index)
                    {
                        case 0:
                            await Detail.Navigation.PushAsync((new MyProfilePage()));
                            break;
                        case 1:
                            await Detail.Navigation.PushAsync((new PurchaseListPage()));
                            break;
                        case 2:
                            await Detail.Navigation.PushAsync(new MyPointsPage());
                            break;
                        case 3:
                            await Detail.Navigation.PushAsync(new CouponsPage());
                            break;
                        case 4:
                            Helpers.Data.Data.QRURL = Helpers.Data.Data.MemberDetails.QRCodePath;
                            await App.Current.MainPage.Navigation.PushPopupAsync(new QRPopupPage());
                            break;
                        case 5:
                            await Detail.Navigation.PushAsync(new CompanyProfilePage());
                            break;
                        case 6:
                            await Detail.Navigation.PushAsync(new BranchesPage());
                            break;
                        case 7:
                            await Detail.Navigation.PushAsync(new TeamMembersPage());
                            break;
                        case 8:
                            await Detail.Navigation.PushAsync(new ContactUsPage());
                            break;
                        case 9:
                            await Detail.Navigation.PushAsync(new InquiryPage());
                            break;
                        case 10:
                            await Detail.Navigation.PushAsync(new FeedbackPage());
                            break;
                        case 11:
                            await viewModel.LogOutCheck();

                            break;
                    }
                    Helpers.Data.Data.SelectedMenu = new MenuItems();
                }
                IsPresented = false;
                listView.SelectedItem = null;
            }
            catch { }
        }

    }
}
