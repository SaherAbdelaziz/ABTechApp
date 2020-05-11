using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ABTechApp.Models;

namespace ABTechApp.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Item { get; set; }
        [Required]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Who should take this order ?")]
        public string AssignedToWho { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }
        public string Heading { get; set; }
    }
}