using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ABTechApp.Models
{
    public class Notification
    {

        public int Id { get; private set; }
        public DateTime DateTime { get;private set; }

        [Required]
        public Order Order { get;private set; }
        
        protected Notification()
        {
            
        }


        public Notification(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            DateTime = DateTime.Now;
            Order = order;
        }
        


    }
}