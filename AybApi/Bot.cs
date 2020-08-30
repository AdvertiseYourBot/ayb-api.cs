using System;

namespace AybApiTest
{
    class Bot
    {
        public string Id;
        public string OwnerId;
        public string Username;
        public string AvatarUrl;
        public int Score;
        public string Category;
        public bool Approved;
        public bool Certified;
        public bool Premium;
        public string Prefix;
        public string Permissions;
        public string Library;
        public string Brief;
        public string Description;
        public string WebsiteUrl;
        public string GitHubUrl;
        public string SupportServerInvite;

        public Bot(string id, string ownerID, string username, string avatarURL, int score, int categoryID, bool approved, bool certified, bool premium, string prefix, string permissions, string library, string brief, string desc, string websiteURL, string githubURL, string supportServerInviteCode)
        {
            Id = id;
            OwnerId = ownerID;
            Username = username;
            AvatarUrl = avatarURL;
            Score = score;
            Category = categoryID.ToString();
            Approved = approved;
            Certified = certified;
            Premium = premium;
            Prefix = prefix;
            Permissions = permissions;
            Library = library;
            Brief = brief;
            Description = desc;
            WebsiteUrl = websiteURL;
            GitHubUrl = githubURL;
            SupportServerInvite = "https://discord.gg/" + supportServerInviteCode;
        }

        public void GetCategory(Action<Exception, Category> callback)
        {
            Client.GetCategory(this.Category, callback);
        }
    }
}