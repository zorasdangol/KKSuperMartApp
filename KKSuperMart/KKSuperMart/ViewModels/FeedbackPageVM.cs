using KKSuperMart.Models;
using KKSuperMart.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KKSuperMart.ViewModels
{
    public class FeedbackPageVM:BaseViewModel
    {
        private Feedback _Feedback;
        public Feedback Feedback
        {
            get { return _Feedback; }
            set { _Feedback = value; OnPropertyChanged("Feedback"); }
        }

        public Command SubmitCommand { get; set; }

        public FeedbackPageVM()
        {
            try
            {
                SubmitCommand = new Command(() => ExecuteSubmitCommand());
                Feedback = new Feedback()
                {
                    COMPANYID = Helpers.Data.Constants.CompanyId,
                    MEMBERID = Helpers.Data.Data.MemberDetails.email
                };
            }
            catch { }
        }

        public async void ExecuteSubmitCommand()
        {
            await FeedbackConnections.FeedbackSubmit(Feedback);
        }
    }
}
