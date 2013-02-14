using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Windows8Privacy.Models;

namespace Windows8Privacy.Controllers
{
    public class PrivacyController : BaseController
    {
        //
        // GET: /Privacy/

        public ActionResult Index(string dev, string app, string mail, string lng)
        {
            if (string.IsNullOrWhiteSpace(dev) ||
                string.IsNullOrWhiteSpace(app) ||
                string.IsNullOrWhiteSpace(mail))
                return RedirectToAction("Index", "Home");

            try
            {
                var lang = GetLanguage(lng);

                return View(new PrivacyModel() { Dev = dev, App = app, Lng = lang, Mail = DecodeFrom64(mail) });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public static string DecodeFrom64(string encodedData)
        {

            byte[] encodedDataAsBytes

                = System.Convert.FromBase64String(encodedData);

            string returnValue =

               System.Text.Encoding.UTF8.GetString(encodedDataAsBytes);

            return returnValue;
        }
    }
}
