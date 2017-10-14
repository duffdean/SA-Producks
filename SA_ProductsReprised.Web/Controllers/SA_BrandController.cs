using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SA_ProductsReprised.Models;
using SA_ProductsReprised.Service.Interfaces;

namespace SA_ProductsReprised.Web.Controllers
{
    public class SA_BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public SA_BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public ActionResult Index()
        {
            var brands = _brandService.GetAll();

            //var model = brands.Select(_brandSummaryMapper.Map).ToList();

            return View(brands);
        }
    }
}
