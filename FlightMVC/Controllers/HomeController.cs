using System.Web.Mvc;

namespace OnlineFlightBooking.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Main() //View has the Layout for the Master page
        {
            return View();
        }
    }
}