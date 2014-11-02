using System.Web.Mvc;
using System.Linq;
using InternetShop.Models.Shop;
using InternetShop.Models.Shop.Entities;
using System.IO;

namespace InternetShop.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/List?page=1

        public ActionResult List(int? page, int? categoryId)
        {
            categoryId = categoryId ?? 0;
            page = page ?? 1;
            var context = new ShopDbContext();
            var products = context.Products.Where(p => categoryId == 0 || p.Category.Id == categoryId.Value).OrderBy(p => p.Name);

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

    }
}
