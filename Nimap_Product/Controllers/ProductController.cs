using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nimap_Product.Models;

namespace Nimap_Product.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration configuration;
        private ProductDAL db;

        public ProductController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.db = new ProductDAL(this.configuration);
        }
        public ActionResult Index()
        {
            var list =db.list();
            return View(list);
        }

        public ActionResult Details(int pid)
        {
            var product = db.GetProductById( pid);

            return View(product);
        }


        public ActionResult AddProduct(int id )
        {  
            return View ();
        }
        public IActionResult AddProduct(Products prod)
        {
            try
            {
                int result = db.AddProduct(prod);
                if (result == 1)
                {

                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View();

                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }

        public ActionResult UpdateProduct(Products prod)
        {
            int result = db.UpdateProduct(prod);
            if (result == 1)
            {
                return RedirectToAction(nameof(Index));
            }

            else return View();


        }

            public IActionResult ProductList()
            {
                var list = db.list();
                return View(list);
            }



        



    }
}
