using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    //public class MaxWordsAttribute : ValidationAttribute
    //{
    //    public MaxWordsAttribute(int maxWords) : base("{0} has to many words.")
    //    {
    //        _maxWords = maxWords;
    //    }

    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        if (validationContext != null)
    //        {
    //            var valueAsString = value.ToString();
    //            if (valueAsString.Split(' ').Length > _maxWords) 
    //            {
    //                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
    //                return new ValidationResult(errorMessage);
    //            }
    //        }
    //        return ValidationResult.Success; 
    //    }

    //    private readonly int _maxWords;
    //}

    public class RestaurantReview : IValidatableObject
    {
        public int Id { get; set; }     
        [Range(1,10)]   
        public int Rating { get; set; }
        [Required]
        [StringLength(1024)]
        public string Body { get; set; }
        [Display(Name ="User name")]
        [DisplayFormat(NullDisplayText ="anonynous")]        
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Rating < 2)
            {
                yield return new ValidationResult("Sorry, you cant do this");
            }
        }
    }
}