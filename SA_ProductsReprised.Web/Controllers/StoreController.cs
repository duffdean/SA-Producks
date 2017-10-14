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
            var products = _productService.GetAllWithUnderCutters();
            //var model = products.Select(_productSummaryMapper.Map).ToList();

            return View(products);
        }
    }
}

