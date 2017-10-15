using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SA_ProductsReprised.Models;
using SA_ProductsReprised.Service.Interfaces;
using SA_ProductsReprised.Service;
using SA_ProductsReprised.Repositoty.Interfaces;

namespace SA_ProductsReprised.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;

        public StoreController(IProductService productService, IBrandService brandService, 
            ICategoryService categoryService)
        {
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            //Need to honour soft delete again...
            //So will have to only return active categories in the service layer.
            var categories = _categoryService.GetAllWithUnderCutters();
            
            return View(categories);
        }

        public ActionResult Products(int categoryId)
        {
            var products = _productService.GetAllWithUnderCutters();
            //Should be doing this work in the service layer...
            products = products.Where(p => p.CategoryID == categoryId);
            
            //Also need to display Out Of Stock when stock level is 0, and not just displaying 0
            //Need to also pass through using ViewModel object and not the DTO object.

            return View(products);
        }
    }
}

