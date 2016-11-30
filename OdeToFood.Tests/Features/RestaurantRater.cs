using System;
using OdeToFood.Models;

namespace OdeToFood.Tests.Features
{
    internal class RestaurantRater
    {
        private Restaurant _restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            this._restaurant = restaurant;
        }

        public RatingResult ComputeRating(int numberOfReviews)
        {
            var results = new RatingResult();
            results.Rating = 4;
            return results;
        }
    }
}