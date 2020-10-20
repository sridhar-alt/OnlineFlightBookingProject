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
                UserBL.RegisterUser(user);
                TempData["message"] = "registered successfull..";
                return RedirectToAction("SignIn");
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
                        return RedirectToAction("UserDisplay", "User");
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
        // GET: User/Display
        [HttpGet]
        public ActionResult UserDisplay()
        {
            IEnumerable<Flight> flights = FlightBL.DisplayFlight();
            return View(flights);           //Calling View for the User Flight Display
        }
    }
}