using System;
using System.Collections.Generic;
using System.Net.Http;
using KKSuperMart.Models;
using Newtonsoft.Json;
using KKSuperMart.Services;

namespace KKSuperMart.ViewModels
{
    public class TeamMembersPageVM:BaseViewModel
    {
        private List<TeamMember> _TeamMembers;
        public List<TeamMember> TeamMembers
        { 
            get { return _TeamMembers; } 
            set { _TeamMembers = value; OnPropertyChanged("TeamMembers"); } 
        }

        public TeamMembersPageVM()
        {
            TeamMembers = new List<TeamMember>();
            LoadTeamMembers();
        }

        public async void LoadTeamMembers()
        {
            try
            {

                bool result = await ApiConnections.LoadTeamMembers();
                if (result)
                {
                    TeamMembers = Helpers.Data.Data.TeamMembers;
                }
                else
                {
                    if (Helpers.Data.Data.TeamMembers == null || Helpers.Data.Data.TeamMembers.Count == 0)
                    {
                        TeamMembers = new List<TeamMember>();
                    }
                    else
                    {
                        TeamMembers = Helpers.Data.Data.TeamMembers;
                    }
                    await App.Current.MainPage.DisplayAlert("Error", "Cannot Connect to Server", "Ok");
                }
              
            }
            catch (Exception e) { await App.Current.MainPage.DisplayAlert("Error", "Cannot connect to server:\n" + e.Message, "Ok"); }

        }
       
    }
}
