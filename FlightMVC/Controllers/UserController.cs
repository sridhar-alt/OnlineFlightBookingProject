using OnilneFlightBooking.Entity;
using System.Web.Mvc;
using OnlineFlightBooking.Models;
using OnlineFlightBooking.BL;
using System.Collections.Generic;
using System.Web.Security;
using System.Web;
using System;

namespace OnlineFlightBooking.Controllers
{
    [HandleError]

    public class UserController : Controller
    {
        // GET: User/SignUp
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();          //Calling View for the SignUp 
        }

        // POST: User/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpModel signUp)
        {
            if (ModelState.IsValid)  //condition pass when all the model state validation is true
            {
                User user = AutoMapper.Mapper.Map<SignUpModel, User>(signUp);    //Auto Mapper model to entity
                bool result = UserBL.ValidateUser(user);
                if (result)
                {
                    UserBL.RegisterUser(user);
                    TempData["message"] = "registered successfull..";
                    return RedirectToAction("SignIn");
                }
                else
                {
                    ViewBag.Message = "user already exists or Mobile no exists";
                    return View();
                }
            }
            return View();          //Calling View for the SignUp(when the ModelState is in valid)
        }
        // GET: User/SignIn
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();          //Calling View for the SignUp 
        }
        // POST: User/SignIn/role
        [HttpPost]
        public ActionResult SignIn(SignInModel signIn)
        {
            if (ModelState.IsValid)     //condition pass when all the model state validation is true
            {
                User user = AutoMapper.Mapper.Map<SignInModel, User>(signIn);   //Auto Mapper model to entity
                string role = UserBL.ValidateLogin(user);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Mobile, false);
                    var authTicket = new FormsAuthenticationTicket(1, user.Mobile, DateTime.Now, DateTime.Now.AddMinutes(20), false, role);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    if (role == "admin")            //Check the roll is admin
                    {
                        TempData["message"] = "Admin Login successfull";
                        return RedirectToAction("Displayflight", "Flight");
                    }
                    else if (role == "User")     //Check the roll is User
                    {
                        TempData["message"] = "user Login successfull";
                        TempData["UserMobile"] =user.Mobile;
                        return RedirectToAction("Search", "Home");
                    }
                    ViewBag.message = "Incorrect mobile number or password";
                }
            }
            return View();      //Calling View for the SignIn (when the ModelState is in valid)
        }
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
        }
        [HttpGet]
        public ActionResult BookTicket(int id)
        {
            TempData["FlightTravelClass"] = FlightBL.DisplayClass(id);
            TempData["TravelClass"] = FlightBL.GetTravelClass();
            Flight flight = FlightBL.GetFlightDetails(id);
            FlightModel flightModel = AutoMapper.Mapper.Map<Flight, FlightModel>(flight);
            TempData["FlightId"] = flight.FlightId;
            return View(flightModel);
        }
        [HttpGet]
        public ActionResult TicketCount(int id)
        {
            string mobile = TempData.Peek("UserMobile").ToString();
            FlightTravelClass flightTravelClass = FlightBL.GetDetailsClass(id);
            //return View(ticketBookModel);
            TicketBook ticketBook = FlightBL.GetBook(flightTravelClass, mobile);
            TicketBookModel ticketBookModel = new TicketBookModel();
            Flight flight = FlightBL.GetFlightDetails(flightTravelClass.FlightId);
            TravelClass travelClass = FlightBL.GetTravelClassName(flightTravelClass.ClassId);
            if (ticketBook==null)
            {
                FlightTravelClassModel flightTravelClassModel = AutoMapper.Mapper.Map<FlightTravelClass, FlightTravelClassModel>(flightTravelClass);       //Auto Mapper entity to model
                FlightModel flightModel = AutoMapper.Mapper.Map<Flight, FlightModel>(flight);
                ticketBookModel.FlightId = flight.FlightId;
                ticketBookModel.ClassId = flightTravelClass.ClassId;
                ticketBookModel.TotalPassenger = 1;
                ticketBookModel.TotalCost = flightTravelClass.SeatCost;
                ticketBookModel.FlightTravelClassId = flightTravelClass.FlightTravelClassId;
                ticketBookModel.Mobile = mobile;
                TempData["Flight Name"] = flight.FlightName;
                TempData["classname"] = travelClass.ClassName;
                TicketBook ticket = AutoMapper.Mapper.Map<TicketBookModel, TicketBook>(ticketBookModel);
                FlightBL.AddTicketBook(ticket);
                return View(ticketBookModel);
            }
            TempData["Flight Name"] = flight.FlightName;
            TempData["classname"] = travelClass.ClassName;
            ticketBookModel = AutoMapper.Mapper.Map<TicketBook, TicketBookModel> (ticketBook);
            return View(ticketBookModel);
        }
        [HttpPost]
        public ActionResult TicketCount(TicketBookModel ticketBook)
        {
            return View(ticketBook);
        }
       [HttpGet]
       public ActionResult IncPassenger(int id)
        {
            TicketBook ticketBook = FlightBL.GetBook(id);
            FlightTravelClass flightTravelClass = FlightBL.GetFlightTravelClass(ticketBook.FlightId,ticketBook.ClassId);
            ticketBook.TotalPassenger = ticketBook.TotalPassenger + 1;
            ticketBook.TotalCost = flightTravelClass.SeatCost * ticketBook.TotalPassenger;
            FlightBL.UpdateTicketBook(ticketBook);
            return RedirectToAction("TicketCount",new { id=ticketBook.TicketId});
        }
        [HttpGet]
        public ActionResult DecPassenger(int id)
        {
            TicketBook ticketBook = FlightBL.GetBook(id);
            FlightTravelClass flightTravelClass = FlightBL.GetFlightTravelClass(ticketBook.FlightId, ticketBook.ClassId);
            if(ticketBook.TotalPassenger>1)
            ticketBook.TotalPassenger = ticketBook.TotalPassenger - 1;
            ticketBook.TotalCost = flightTravelClass.SeatCost * ticketBook.TotalPassenger;
            FlightBL.UpdateTicketBook(ticketBook);
            return RedirectToAction("TicketCount", new { id = ticketBook.TicketId });
        }
        [HttpGet]
        public ActionResult ViewTicketBook()
        {
            string userId = TempData.Peek("UserMobile").ToString();
            IEnumerable<TicketBook> ticket = FlightBL.GetBookUser(userId);
            TempData["flights"] = FlightBL.DisplayFlight();
            TempData["TravelClass"] = FlightBL.GetTravelClass();
            return View(ticket);
        }
        [HttpGet]
        public ActionResult DeleteTicketCount(int id)
        {
            FlightBL.DeleteTicketCount(id);
            return RedirectToAction("ViewTicketBook");
        }
        [HttpGet]
        public ActionResult Payment(int id)
        {
            return View();
        }
    }
}