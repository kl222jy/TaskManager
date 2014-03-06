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
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="validationResults"></param>
        /// <returns></returns>
        public static bool Validate<T>(this T instance, out ICollection<ValidationResult> validationResults)
        {
            var validationContext = new ValidationContext(instance);
            validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(instance, validationContext, validationResults, true);
        }
    }
}