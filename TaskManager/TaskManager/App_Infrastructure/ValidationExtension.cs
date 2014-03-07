using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager
{
    public static class ValidationExtension
    {
        /// <summary>
        /// Implements easy validation based on data annotations (obj.validate)
        /// </summary>
        /// <param name="obj">object to validate</param>
        /// <param name="validationResults">output of results</param>
        /// <returns>true/false - success/failure</returns>
        public static bool TryValidate(this object obj, out ICollection<ValidationResult> validationResults)
        {
            var validationContext = new ValidationContext(obj);
            validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }

        //public static bool Validate<T>(this T instance, out ICollection<ValidationResult> validationResults)
        //{
        //    var validationContext = new ValidationContext(instance);
        //    validationResults = new List<ValidationResult>();

        //    return Validator.TryValidateObject(instance, validationContext, validationResults, true);
        //}




    }
}