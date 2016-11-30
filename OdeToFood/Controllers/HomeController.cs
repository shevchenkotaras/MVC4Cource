﻿using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Autocomplete(string term)
        {
            var model = _db.Restaurants
                .Where(r => r.Name.StartsWith(term))
                .Take(10)
                .Select(r => new
                {
                    label = r.Name
                });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        
        [OutputCache(CacheProfile ="Long", VaryByHeader = "X-Requested-With", Location = OutputCacheLocation.Server)]
        public ActionResult Index(string searchTerm = null, int page = 1)
        {           
            var model = _db.Restaurants
                .OrderByDescending(restaurant => restaurant.Reviews.Average(review => review.Rating))
                .Where(restaurant => searchTerm == null || restaurant.Name.StartsWith(searchTerm))                
                .Select(restaurant => new RestaurantListViewModel
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    City = restaurant.City,
                    Country = restaurant.Country,
                    CountOfReviews = restaurant.Reviews.Count()
                }).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}