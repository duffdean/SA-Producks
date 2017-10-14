using SA_ProductsReprised.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SA_ProductsReprised.Web.Controllers
{
    public class SA_CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public SA_CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var categorys = _categoryService.GetAll();

            //var model = categorys.Select(_categorySummaryMapper.Map).ToList();

            return View(categorys);
        }
    }
}