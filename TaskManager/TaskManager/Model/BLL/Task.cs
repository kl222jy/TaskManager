using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Model
{
    public class Task
    {
        [Key]
        public int TaskID { get; set; }
        [Required(ErrorMessage = "Description cannot be empty"), StringLength(500, ErrorMessage = "Description can be at most 500 characters.")]
        public string TaskDescription { get; set; }
        [Required]
        public int ProjectID { get; set; }
        [Required]
        public int TaskStatusID { get; set; }
    }
}