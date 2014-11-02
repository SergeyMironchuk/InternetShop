using System.Web.Mvc;
using System.Linq;
using InternetShop.Models.Shop;
using InternetShop.Models.Shop.Entities;
using System.IO;

namespace InternetShop.Controllers
{
    public class ProductsController : Controller
    {
        private Cart GetCart()
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new Cart();
            }
            var cart = (Cart) Session["Cart"];
            return cart;
        }

        //
        // GET: /Products/List?page=1

        public ActionResult List(int? page, int? categoryId)
        {
            categoryId = categoryId ?? 0;
            page = page ?? 1;
            var context = new ShopDbContext();
            var products = context.Products.Where(p => categoryId == 0 || p.Category.Id == categoryId.Value);
            var pageableData = new PageableData<Product>(products, p => p.Id, page.Value);
            ViewBag.NextPage = (page.Value + 1) > pageableData.CountPage ? pageableData.CountPage : page.Value + 1;
            ViewBag.PrevPage = (page.Value - 1) < 1 ? 1 : page.Value - 1;
            ViewBag.CategoryId = categoryId;
            return View(pageableData);
        }

        // GET: /Products/Categories?categoryId=

        public ActionResult Categories(int? categoryId)
        {
            var context = new ShopDbContext();
            var category = context.Categories;
            ViewBag.ThisCategory = categoryId;
            return PartialView(category);
        }

        // GET: /Products/Image?productId=

        public FilePathResult Image(int? productId)
        {
            productId = productId ?? 0;
            string fileName = Server.MapPath("~\\App_Data\\products\\" + productId.Value + ".jpg");
            if (System.IO.File.Exists(fileName))
            {
                return File(fileName, "image/jpg");
            }
            else
            {
                fileName = Server.MapPath("~\\App_Data\\products\\undefined.png" );
                return File(fileName, "image/png");
            }
        }

        // POST: /Products/AddToCart

        [HttpPost]
        public ActionResult AddToCart(int kolich, int productId)
        {
            var context = new ShopDbContext();
            var product = context.Products.FirstOrDefault(p => p.Id==productId);
            var cart = GetCart();
            cart.OrderLines.Add(new OrderLine { Kolich = kolich, Product = product });
            cart.countOfProd = cart.countOfProd + kolich;
            return RedirectToAction("List");
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
            
              cart.OrderLines.Add(new OrderLine { Kolich = kolich, Product = product });
            cart.countOfProd = cart.countOfProd + kolich;
            return RedirectToAction("List");
        }
    }
}
