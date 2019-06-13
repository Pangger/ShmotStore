using Microsoft.AspNet.Identity;
using ShmotStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShmotStore.Controllers
{
    public class CheckoutController : Controller
    {
        ShopContext db = new ShopContext();
        // GET: Checkout
        [Authorize(Roles = "admin, user")]
        public ActionResult Index()
        {
            Cart cart = (Cart)Session["cart"];
            CartViewModel cartViewModel = new CartViewModel();
            cartViewModel.Products = cart.GetProdcts();
            return View(cartViewModel);
        }

        [Authorize(Roles = "admin, user")]
        public ActionResult Buy()
        {
            Order order = new Order();
            order.OrderTime = DateTime.Now;
            Cart cart = (Cart)Session["cart"];
            var products = cart.GetProdcts();
            if(products != null)
            {
                foreach(var product in products)
                {
                    order.Products.Add(product);
                }
            }
            order.UserId = User.Identity.GetUserId();

            db.Orders.Add(order);
            db.SaveChanges();

            return Redirect("Thanks");
        }

        [Authorize(Roles = "admin, user")]
        public ActionResult Thanks()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}