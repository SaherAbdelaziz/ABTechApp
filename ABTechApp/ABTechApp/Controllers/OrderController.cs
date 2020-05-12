using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABTechApp.Models;
using ABTechApp.ViewModels;
using Microsoft.AspNet.Identity;
namespace ABTechApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController()
        {
            _context = new ApplicationDbContext();
        }
        

        // GET: Order
        [Authorize]
        public ActionResult Index()
        {
            var orders = _context.Orders
                .Include(o=>o.WhoAssignedThis)
                .Include(o=>o.AssignedToWho)
                .ToList();

            return View(orders);
        }

        [Authorize]
        public ActionResult New()
        {
            var viewModel = new OrderViewModel
            {
                Users = _context.Users.ToList(),
                Heading = "New Order"
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                viewModel.Users = _context.Users.ToList();

                return View("New", viewModel);
            }

            var order = new Order
            {
                WhoAssignedThisId = User.Identity.GetUserId(),
                Name = viewModel.Name,
                Item = viewModel.Item,
                Phone = viewModel.Phone,
                Location = viewModel.Location,
                AssignedToWhoId = viewModel.AssignedToWho
            };

            var user = _context.Users.Single(u => u.Id == viewModel.AssignedToWho);
            user.Notify(new Notification(order));
            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Mine", "Order");
        }

        public ActionResult Details(int id)
        {
            var order = _context.Orders
                .Include(o => o.WhoAssignedThis)
                .Include(o => o.AssignedToWho)
                .Single(o => o.Id == id);
                 

            return View(order);
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();

            var orders = _context.Orders
                .Where(o=>o.AssignedToWhoId == userId)
                .Include(o=>o.WhoAssignedThis)
                .Include(o=>o.AssignedToWho)
                .ToList();
            

            return View(orders);
        }
    }
}