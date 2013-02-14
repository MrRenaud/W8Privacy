using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Windows8Privacy.Controllers
{
    public class BaseController : Controller
    {
        protected Language GetLanguage(string lng)
        {
            if (string.IsNullOrWhiteSpace(lng))
            {
                // Attempt to read the culture cookie from Request
                HttpCookie cultureCookie = Request.Cookies["settings"];
                if (cultureCookie != null)
                    lng = cultureCookie["_culture"];
                else
                    lng = Request.UserLanguages[0]; // obtain it from HTTP header AcceptLanguages
            }
            // Validate culture name
            lng = CultureHelper.GetImplementedCulture(lng); // This is safe

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lng);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;


            HttpCookie myCookie = new HttpCookie("settings");
            myCookie["_culture"] = lng;
            myCookie.Expires = DateTime.Now.AddDays(10);
            HttpContext.Response.Cookies.Add(myCookie);

            Language lang;

            switch (lng)
            {
                case "fr":
                    lang = Language.Fr;
                    break;
                case "nl":
                    lang = Language.Nl;
                    break;
                case "en":
                default:
                    lang = Language.En;
                    break;
            }

            return lang;
        }
    }
}