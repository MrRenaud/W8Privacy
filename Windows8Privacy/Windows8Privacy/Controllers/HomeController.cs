using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Windows8Privacy.Controllers
{
    public enum Language
    {
        En,
        Fr,
        Nl
    }

    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index(string lng = "")
        {
            var lang = GetLanguage(lng);

            return View(lang);
        }

        public ActionResult About(string lng = "")
        {
            var lang = GetLanguage(lng);

            return View(lang);
        }
    }
}
