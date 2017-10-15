using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SA_ProductsReprised.Models;
using SA_ProductsReprised.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace SA_ProductsReprised.Web.Controllers
{
    public class SA_ProductController : Controller
    {
        private readonly IProductService _productService;

        public SA_ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var products = _productService.GetAll();
            //var model = products.Select(_productSummaryMapper.Map).ToList();

            return View(products);
        }
    }
}
