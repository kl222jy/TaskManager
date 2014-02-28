using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Model
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Firstname cannot be empty."), StringLength(20, ErrorMessage = "Firstname can be at most 20 characters.")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Lastname cannot be empty."), StringLength(20, ErrorMessage = "Lastname can be at most 20 characters.")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Email cannot be empty."), DataType(DataType.EmailAddress, ErrorMessage = "Email was not a valid emailaddress."), StringLength(30, ErrorMessage = "Email can be at most 30 characters."), EmailAddress(ErrorMessage = "Email was not a valid emailaddress.")]
        public string Email { get; set; }
    }
}