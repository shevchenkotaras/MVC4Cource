using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index()
        {
            //var model = from r in _db.Restaurants
            //            orderby r.Reviews.Average(review => review.Rating) descending
            //            select new RestaurantListViewModel{
            //                Id = r.Id,
            //                Name = r.Name,
            //                City = r.City,
            //                Country = r.Country,
            //                CountOfReviews = r.Reviews.Count()
            //            };

            var model = _db.Restaurants
                .OrderByDescending(restaurant => restaurant.Reviews.Average(review => review.Rating))
                .Select(restaurant => new RestaurantListViewModel
                    {
                        Id = restaurant.Id,
                        Name = restaurant.Name,
                        City = restaurant.City,
                        Country = restaurant.Country,
                        CountOfReviews = restaurant.Reviews.Count()
                    });
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