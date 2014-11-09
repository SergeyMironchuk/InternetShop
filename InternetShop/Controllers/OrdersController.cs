using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InternetShop.Models.Shop;
using InternetShop.Models.Shop.Entities;

namespace InternetShop.Controllers
{
    public class OrdersController : Controller
    {
        private Cart GetCart()
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new Cart();
            }
            var cart = (Cart)Session["Cart"];
            return cart;
        }

        // POST: /Products/AddToCart

        [HttpPost]
        public ActionResult AddToCart(int kolich, int productId)
        {
            var context = new ShopDbContext();
            var product = context.Products.FirstOrDefault(p => p.Id == productId);
            var cart = GetCart();
            cart.OrderLines.Add(new OrderLine { Kolich = kolich, Product = product });
            return RedirectToAction("List", "Products");
        }

        // GET: /Products/CartInfo

        public ActionResult CartInfo()
        {
            return PartialView(GetCart());
        }

        public ActionResult Cart()
        {
            return View(GetCart());
        }

        public ActionResult SendCart(string name, string surname, string phone, Cart cart)
        {
            var context = new Person();

            //cart.OrderLines.Add(new OrderLine { Kolich = kolich, Product = product });
            return RedirectToAction("List", "Products");
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddOrder()
        {
            var userName = User.Identity.Name;
            var context = new ShopDbContext();
            var person = context.Persons.FirstOrDefault(p => p.UserName == userName);
            if (person == null)
            {
                person = new Person {UserName = userName};
                context.Persons.Add(person);
                context.SaveChanges();
            }
            return  View(person);
        }

        [HttpPost]
        public ActionResult AddOrder(Person person)
        {
            if (!ModelState.IsValid || person.Validate().Any())
            {
                foreach (var valuePair in person.Validate())
                {
                    ModelState.AddModelError(valuePair.Key, valuePair.Value);
                }
                return View(person);
            }
            
            var context = new ShopDbContext();
            var personFromDB = context.Persons.FirstOrDefault(p => p.UserName == person.UserName);
            personFromDB.Name = person.Name;
            personFromDB.Surname = person.Surname;
            personFromDB.Phone = person.Phone;
            context.SaveChanges();
                
            var order = new Order();
            order.Date = DateTime.Today;
            order.Person = personFromDB;
            order.OrderLines = GetCart().OrderLines;
            context.Orders.Add(order);
            context.SaveChanges();
                          
            return RedirectToAction("List", "Products");
        }
    }
}
