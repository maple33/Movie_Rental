using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace Movie_Rentals.Models
{
    public class min18yrsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.PayAsYouGo || customer.MembershipTypeId == MembershipType.Unknown)
                return ValidationResult.Success;

            if (customer.birthDate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Now.Year - customer.birthDate.Value.Year;
            if (DateTime.Now.DayOfYear < customer.birthDate.Value.DayOfYear)
                age = age - 1;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer shold be at least 18 years old to go on a membership.");
        }
    }
}