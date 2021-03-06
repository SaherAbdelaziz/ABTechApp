﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABTechApp.Models
{
    public class Order
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
        public string WhoAssignedThisId { get; set; }
        [Required]
        public string AssignedToWhoId { get; set; }

        public ApplicationUser WhoAssignedThis { get; set; }
        public ApplicationUser AssignedToWho { get; set; }
    }
}