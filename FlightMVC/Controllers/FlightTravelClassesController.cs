﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using OnilneFlightBooking.Entity;
using OnlineFlightBooking.BL;
using OnlineFlightBooking.Models;

namespace OnlineFlightBooking.Controllers
{
    public class FlightTravelClassesController : Controller
    {

        // GET: FlightTravelClasses
        public ActionResult DisplayClass()
        {
            int flightId = Convert.ToInt32(TempData["FlightId"]);
            IEnumerable<FlightTravelClass> TravelClass = FlightBL.DisplayClass(flightId);
            return View(TravelClass);       
        }
        // GET: FlightTravelClasses/GetTravelClass
        [HttpGet]
        public ActionResult CreateClass()
        {
            FlightTravelClass flightTravelClass = new FlightTravelClass();
            flightTravelClass.FlightId = Convert.ToInt32(TempData["FlightId"]);
            ViewBag.ClassId = new SelectList(FlightBL.GetTravelClass(),"ClassId", "ClassName");
            FlightTravelClassModel flightTravelClassModel= AutoMapper.Mapper.Map<FlightTravelClass, FlightTravelClassModel>(flightTravelClass);     //Auto Mapper entity to model
            return View(flightTravelClassModel);
        }
        // POST: FlightTravelClasses/GetTravelClass
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClass( FlightTravelClassModel flightTravelClassModel)
        {
            if (ModelState.IsValid)     //condition pass when all the model state validation is true
            {
                FlightTravelClass create = AutoMapper.Mapper.Map<FlightTravelClassModel,FlightTravelClass>(flightTravelClassModel);     //Auto Mapper model to entity
                FlightBL.CreateClass(create);
                TempData["FlightId"] = create.FlightId;
                return RedirectToAction("DisplayFlight","Flight");
            }
            ViewBag.Class_Id = new SelectList(FlightBL.GetTravelClass(), "ClassId", "ClassName", flightTravelClassModel.ClassId);
            return View(flightTravelClassModel);            //Calling View for the Create Class(when the ModelState is in valid)
        }
        [HttpGet]
        // GET: FlightTravelClasses/Edit/5
        public ActionResult EditClass(int id)
        {
            FlightTravelClass flightTravelClass =FlightBL.GetDetailsClass(id);
            IEnumerable<TravelClass> travelClass=FlightBL.GetTravelClass();
            ViewBag.ClassId = new SelectList(travelClass, "ClassId", "ClassName");
            FlightTravelClassModel flightTravelClassModel = AutoMapper.Mapper.Map<FlightTravelClass, FlightTravelClassModel>(flightTravelClass);       //Auto Mapper entity to model
            return View(flightTravelClassModel);
        }
        // POST: FlightTravelClasses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditClass(FlightTravelClassModel flightTravelClass)
        {
            if (ModelState.IsValid)     //condition pass when all the model state validation is true
            {
                FlightTravelClass edit = AutoMapper.Mapper.Map<FlightTravelClassModel, FlightTravelClass>(flightTravelClass);     //Auto Mapper model to entity
                FlightBL.EditClass(edit);
                return RedirectToAction("DisplayFlight","Flight");
            }
            ViewBag.Flight_Id = new SelectList(FlightBL.DisplayFlight(), "FlightId", "FlightName", flightTravelClass.FlightId);
            ViewBag.Class_Id = new SelectList(FlightBL.GetTravelClass(), "ClassId", "ClassName", flightTravelClass.ClassId);
            return View(flightTravelClass);     //Calling View for the Edit Class(when the ModelState is in valid)
        }

        [HttpGet]
        // GET: FlightTravelClasses/Delete/5
        public ActionResult DeleteClass(int id)
        {
            FlightTravelClass flightTravelClass = FlightBL.GetDetailsClass(id);
            ViewBag.ClassId = new SelectList(FlightBL.GetTravelClass(), "ClassId", "ClassName");
            FlightTravelClassModel delete = AutoMapper.Mapper.Map<FlightTravelClass,FlightTravelClassModel>(flightTravelClass);     //Auto Mapper entity to model
            return View(delete);
        }

        // POST: FlightTravelClasses/Delete/5
        [HttpPost]
        public ActionResult DeleteClass(FlightTravelClassModel delete)
        {
            FlightTravelClass flightTravelClass = AutoMapper.Mapper.Map<FlightTravelClassModel, FlightTravelClass>(delete);     //Auto Mapper model to entity
            FlightBL.DeleteFlightTravelClass(flightTravelClass);
            return RedirectToAction("DisplayFlight","Flight");
        }
    }
}
