using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nimap_Product.Models;

namespace Nimap_Product.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration configuration ; 
        CategoryDAL crud ;

        public CategoryController(IConfiguration configuration)
        {
            this.configuration = configuration;
            crud = new CategoryDAL(configuration);

        }
        public IActionResult Index()
        {
            var list =crud.List();
            
            return View(list);

        }


        public ActionResult Details()
        {
            var cat = crud.List();
            return View(cat);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category cad)
        {
            int result = crud.AddCategory(cad);

            if (result == 1) {
                return RedirectToAction(nameof(Index));
            }
            else return View();
        }

        public ActionResult Delete (int CategoryId) 
        {

            var cat =crud.GetCategoryById(CategoryId);
            return View(cat);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Deletec (int CategoryId)
        {
            int result = 0;
            result = crud.DeleteCategory(CategoryId);
            if (result == 1)
            {
                return RedirectToAction(nameof(Index));
            }
            else return View();

        }
    }
}
