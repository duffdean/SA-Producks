using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace ProductsReprised.Controllers
{
    public class ProductController : Controller
    {
        private Core.Interfaces.ProductRepository productRepository;

        public ProductController()
        {
            this.productRepository = new Core.Interfaces.ProductRepository(new Core.DataContext());
        }

        public ActionResult Index()
        {
            IEnumerable<Models.Product> prod = productRepository.GetProducts();
            return View(prod);
        }
    }
}