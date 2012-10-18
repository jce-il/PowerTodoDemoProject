using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Facebook;

namespace PowerTodoApp.Models
{
    public class FacebookService : IFriendService
    {
        private readonly FacebookClient _fb;

        public FacebookService()
        {
            _fb = new FacebookClient();
        }

        public IEnumerable<Friend> All
        {
            get {
                _fb.AccessToken = HttpContext.Current.Session["fb_access_token"] as string;
                dynamic friends = _fb.Get("me/friends");
                var friendlist = (friends.data as Facebook.JsonArray).ToDictionary(
                    p => (p as Facebook.JsonObject)["id"].ToString(),
                    p => new Friend { Name = (p as Facebook.JsonObject)["name"].ToString() } );

                friendlist["0"] = new Friend { Name = "Me" };
                //var frienList = from friend in friends
                //                select new Friend { Name = friend.Name };
                return friendlist.Values;
            }
        }
    }
}