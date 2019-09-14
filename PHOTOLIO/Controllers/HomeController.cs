using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PHOTOLIO.Service;
using PHOTOLIO.ViewModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using PHOTOLIO.Model;
using Facebook;
using Newtonsoft.Json;
using System.Web.Security;

namespace PHOTOLIO.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ProductService service = new ProductService();
            List<ProductVM> list = service.SelectList();
            return View(list);

        }
     
        public ActionResult Team()
        {
            return View();
        }
        //public ActionResult Locations()
        //{
        //    return View();
        //}
    

        private Uri RediredtUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("facebookCallback");
                return uriBuilder.Uri;

            }
        }
        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginuUrl = fb.GetLoginUrl(new
            {
                client_id = "738436346575942",
                client_secret = "2bb5232783372f3e8e45bea7427a9d3c",
                redirect_uri = RediredtUri.AbsoluteUri,
                response_type = "code",
                scope = "email"

            });
            return Redirect(loginuUrl.AbsoluteUri);
        }
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = "738436346575942",
            client_secret = "2bb5232783372f3e8e45bea7427a9d3c",
            redirect_uri = RediredtUri.AbsoluteUri,
            response_type = "code",
                code = code
        });
            var accessToken = result.access_token;
         Session["AccessToken"]=accessToken;
            fb.AccessToken=accessToken;

        dynamic me = fb.Get("me?fields=link,first_name,currency,last_name,email,gender,locale,timezone,verified,picture,age_range");
        string email = me.email;
        string lastname = me.last_name;
        string picture = me.picture.data.url;
        FormsAuthentication.SetAuthCookie(email, false);
        return RedirectToAction("Index","Home");
    }

}
}