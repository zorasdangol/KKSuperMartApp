using KKSuperMart.Services;
using System;
using System.Collections.Generic;
using System.Text;
using KKSuperMart.Models;
using System.Linq;

namespace KKSuperMart.ViewModels
{
    public class InquiryHistoryPageVM : BaseViewModel
    {

        private List<Message> _ChatMessages;
        public List<Message> ChatMessages
        {
            get { return _ChatMessages; }
            set { _ChatMessages = value; OnPropertyChanged("ChatMessages"); }
        }

        public InquiryHistoryPageVM()
        {
            ChatMessages = new List<Message>();
            LoadQueries();            
        }

        public async void LoadQueries()
        {
            try
            {
                bool result = await FeedbackConnections.LoadQueries();
                if (result)
                {
                    ChatMessages = Helpers.Data.Data.ChatMessages;
                    ChatMessages = Helpers.Data.Data.ChatMessages.OrderBy(o => o.REPLYID).ToList();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server" , "Ok");
                    ChatMessages = new List<Message>();
                }

            }catch(Exception e) { await App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server:\n" + e.Message, "Ok"); }
        }
    }
}
