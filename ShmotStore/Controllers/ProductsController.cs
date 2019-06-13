using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ShmotStore.Models;

namespace ShmotStore.Controllers
{
    public class ProductsController : Controller
    {
        private ShopContext db = new ShopContext();
        static Cart cart = new Cart();

        // GET: Products
        public ActionResult Index(string sortType)
        {
            IQueryable<Product> products = db.Products;

            if (sortType == "nameSort")
            {
                products = products.OrderBy(p => p.Name);
            }

            if(sortType == "priceSort")
            {
                products = products.OrderBy(p => p.Price);
            }

            ViewBag.SortType = sortType;

            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Sizes = db.Sizes.ToList();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Product product, int[] selectedCategory, int[] selectedSize)
        {
            if (ModelState.IsValid)
            {
                product.Categories.Clear();
                if (selectedCategory != null)
                {
                    foreach (var category in db.Categories.Where(m => selectedCategory.Contains(m.CategoryId)))
                    {
                        product.Categories.Add(category);
                    }
                }
                product.Sizes.Clear();
                if (selectedSize != null)
                {
                    foreach (var size in db.Sizes.Where(m => selectedCategory.Contains(m.SizeId)))
                    {
                        product.Sizes.Add(size);
                    }
                }

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Sizes = db.Sizes.ToList();
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Product product, int[] selectedCategory, int[] selectedSize)
        {
            if (ModelState.IsValid)
            {
                Product newProduct = db.Products.Find(product.ProductId);

                newProduct.Name = product.Name;
                newProduct.Description = product.Description;
                newProduct.Price = product.Price;
                newProduct.Sex = product.Sex;

                newProduct.Categories.Clear();
                if (selectedCategory != null)
                {
                    foreach (var category in db.Categories.Where(m => selectedCategory.Contains(m.CategoryId)))
                    {
                        newProduct.Categories.Add(category);
                    }
                }

                newProduct.Sizes.Clear();
                if (selectedSize != null)
                {
                    foreach (var size in db.Sizes.Where(m => selectedSize.Contains(m.SizeId)))
                    {
                        newProduct.Sizes.Add(size);
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        
        [Authorize(Roles = "user, admin")]
        public ActionResult AddToCart(int id, int quantity = 1)
        {
            var product = db.Products.Find(id);
            cart.AddItem(product);
            Session["cart"] = cart;
            return Redirect("~/Products/Index");
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
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
