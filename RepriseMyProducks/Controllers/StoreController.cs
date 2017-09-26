using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Producks.Model;

namespace RepriseMyProducks.Controllers
{
    public class StoreController : Controller
    {
        private StoreDb db = new StoreDb();

        // GET: Store
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Products(Int32 Id)
        {
            return View(db.Products.ToList());
        }
    }
}