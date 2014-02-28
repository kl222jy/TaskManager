using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Model
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Name cannot be empty."), StringLength(30, ErrorMessage = "Name can be at most 30 characters.")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Description cannot be empty."), StringLength(500, ErrorMessage = "Description can be at most 500 characters.")]
        public string ProjectDescription { get; set; }
    }
}