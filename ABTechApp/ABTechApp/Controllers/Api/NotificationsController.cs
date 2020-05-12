using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ABTechApp.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace ABTechApp.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Notification> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Order.AssignedToWho)
                .Include(n => n.Order.WhoAssignedThis)
                .ToList();

            return notifications;
        }
    }

}
}
