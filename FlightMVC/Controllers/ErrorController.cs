using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineFlightBooking.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult ErrorFound()
        {
            return View();
        }
    }
}