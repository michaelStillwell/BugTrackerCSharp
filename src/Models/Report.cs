using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class Report
    {
        public int ID {get; set;}

        [StringLength(60, MinimumLength = 5)]
        [Required]
        public string Title {get; set;}

        [StringLength(255, MinimumLength =10)]
        public string Description {get; set;}

        [Required]
        public bool Status {get; set;}
        
        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        public DateTime DateCreated {get; set;}
        public string Priority {get; set;}
    }
}