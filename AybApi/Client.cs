using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace AybApiTest
{
    class Client
    {
        public static string baseUrl = "http://api.ayblisting.com";

        private static async void Get(string url, Action<JObject> callback)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        if (content != null)
                        {
                            JObject result = JObject.Parse(data);
                            callback(result);
                        }
                        else
                        {
                            callback(null);
                        }
                    }
                }
            }
        }

        public static void GetStats(Action<Exception, Stats> callback)
        {
            string url = baseUrl + "/stats";
            try
            {
                Get(url, (JObject stats) =>
                {
                    int bots = stats.Value<int>("bots");
                    int unreadReports = stats.Value<int>("unread_reports");
                    callback(null, new Stats(bots, 0, unreadReports));
                });
            }
            catch (Exception exception)
            {
                callback(exception, null);
            }
        }

        public static void GetBot(string id, Action<Exception, Bot> callback)
        {
            string url = baseUrl + "/bot?id=" + id;
            try
            {
                Get(url, (JObject res) =>
                {
                    bool success = res.Value<bool>("success");

                    Exception err = null;
                    if (!success) err = new Exception(res.Value<string>("note"));

                    string Id = res.Value<string>("clientid");
                    string ownerID = res.Value<string>("ownerid");
                    string username = res.Value<string>("botname");
                    string avatarURL = res.Value<string>("botavatar");
                    int score = res.Value<int>("score");
                    int category = res.Value<int>("category");
                    bool approved = res.Value<bool>("approved");
                    bool certified = res.Value<bool>("certified");
                    bool prem = res.Value<bool>("premium");
                    string prefix = res.Value<string>("prefix");
                    string permissions = res.Value<string>("permissions");
                    string lib = res.Value<string>("library");
                    string brief = res.Value<string>("brief");
                    string desc = res.Value<string>("description");
                    string webUrl = res.Value<string>("websiteurl");
                    string githubUrl = res.Value<string>("github");
                    string inviteCode = res.Value<string>("supportservercode");

                    Bot bot = null;
                    if (success) bot = new Bot(id, ownerID, username, avatarURL, score, category, approved, certified, prem, prefix, permissions, lib, brief, desc, webUrl, githubUrl, inviteCode);

                    callback(err, bot);
                });
            }
            catch (Exception exception)
            {
                callback(exception, null);
            }
        }

        public static void GetCategory(string id, Action<Exception, Category> callback)
        {
            string url = baseUrl + "/bot?id=" + id;
            try
            {
                Get(url, (JObject res) =>
                {
                    bool success = res.Value<bool>("success");

                    Exception err = null;
                    if (!success) err = new Exception(res.Value<string>("note"));

                    string slug = res.Value<string>("slug");
                    string name = res.Value<string>("name");
                    string catId = res.Value<string>("id");

                    Category cat = null;
                    if (success) cat = new Category(catId, name, slug);

                    callback(err, cat);
                });
            }
            catch (Exception exception)
            {
                callback(exception, null);
            }
        }
    }
}