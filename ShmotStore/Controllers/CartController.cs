using ShmotStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShmotStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [Authorize(Roles = "admin, user")]
        public ActionResult Index()
        {
            CartViewModel cartViewModel = new CartViewModel();
            Cart cart = (Cart)Session["cart"];
            cartViewModel.Products = cart?.GetProdcts();
            
            return View(cartViewModel);
        }

        [Authorize(Roles = "admin, user")]
        public ActionResult DeleteItem(int id)
        {
            Cart cart = (Cart)Session["cart"];
            cart.RemoveItem(cart.GetProdcts().First(p => p.ProductId == id));
            Session["cart"] = cart;
            return Redirect("~/Cart/Index");
        }

        [Authorize(Roles = "admin, user")]
        public ActionResult UpdateCart(int[] quantity)
        {
            Cart cart = (Cart)Session["cart"];
            var products = cart.GetProdcts();
            for(int counter = 0; counter < products.Count; counter++)
            {
                
            }
            return Redirect("~/Cart/Index");
        }
    }
}