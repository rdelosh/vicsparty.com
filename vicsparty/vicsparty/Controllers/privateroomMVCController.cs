using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vicsparty.Controllers
{
    public class privateroomMVCController : Controller
    {
        // GET: privateroomMVC
        public ActionResult createroom()
        {

            return View();
        }

        public ActionResult joinroom()
        {
            return View();
        }
    }
}