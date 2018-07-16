using System;
namespace KKSuperMart.Models
{
    public class TeamMember
    {
        public double _id { get; set; }
        public double rank { get; set; }
        public string name { get; set; }
        public string contactno { get; set; }
        public string designation { get; set; }
        public string branch { get; set; }
        public string image { get; set; }

        public static string GenerateTeamMembersURL(string companyid)
        {
            return string.Format(Helpers.Data.Constants.TeamMembersUrl, companyid);
        }
    }
}
