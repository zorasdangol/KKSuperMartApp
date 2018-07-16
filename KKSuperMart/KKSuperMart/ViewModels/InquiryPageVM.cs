using System;
using System.IO;
using System.Net.Http;
using KKSuperMart.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using KKSuperMart.Views;
using KKSuperMart.Services;
using System.Threading.Tasks;

namespace KKSuperMart.ViewModels
{
	public class InquiryPageVM:BaseViewModel
    {
		private Feedback _Feedback;
		public Feedback Feedback{
			get { return _Feedback; }
			set { _Feedback = value;  OnPropertyChanged("Feedback");}
		}

		public Command SubmitCommand { get; set; }
        public Command ChatCommand { get; set; }

        public InquiryPageVM()
        {
			SubmitCommand = new Command( () =>  ExecuteSubmitCommand());
            ChatCommand = new Command(() => ExecuteChatCommand());
            Feedback = new Feedback()
			{
				COMPANYID = Helpers.Data.Constants.CompanyId,
				MEMBERID = Helpers.Data.Data.MemberDetails.email
			};
            
        }       

        public async void ExecuteChatCommand()
        {            
            await (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new InquiryHistoryPage());
        }

        public async void ExecuteSubmitCommand()
        {
            await FeedbackConnections.InquirySubmit(Feedback);
        }        
    }
}
