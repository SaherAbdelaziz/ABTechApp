using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABTechApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Item { get; set; }
        public string Location { get; set; }

        public string WhoAssignedThisId { get; set; }
        public string AssignedToWhoId { get; set; }

        public ApplicationUser WhoAssignedThis { get; set; }
        public ApplicationUser AssignedToWho { get; set; }
    }
}