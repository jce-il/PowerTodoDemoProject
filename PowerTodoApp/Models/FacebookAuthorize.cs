using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PowerTodoApp.Models
{
    public class FacebookAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            var accessToken = httpContext.Session["fb_access_token"] as string;
            if (string.IsNullOrWhiteSpace(accessToken))
                return false;
            return true;
        }
    }
}