using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductsReprised.Data;
using ProductsReprised.Service.Interfaces;
using ProductsReprised.Core.Models;

namespace ProductsReprised.Controllers
{
    public class ProductController : Controller
    {
        private StoreData db = new StoreData();
        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;   
        }

        public ProductController()
        {
        }

        // GET: Product
        public ActionResult Index()
        {
            IEnumerable<Product> products = productService.GetProducts();

            return View(products);

            //var sA_Product = db.SA_Product.Include(s => s.SA_Brand).Include(s => s.SA_Category).Include(s => s.SA_Product1);
            //return View(sA_Product.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SA_Product sA_Product = db.SA_Product.Find(id);
            if (sA_Product == null)
            {
                return HttpNotFound();
            }
            return View(sA_Product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.SA_Brand, "ID", "Name");
            ViewBag.CategoryID = new SelectList(db.SA_Category, "ID", "Name");
            ViewBag.ID = new SelectList(db.SA_Product, "ID", "Name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CategoryID,BrandID,Name,Description,Price,StockLevel,Active")] SA_Product sA_Product)
        {
            if (ModelState.IsValid)
            {
                db.SA_Product.Add(sA_Product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.SA_Brand, "ID", "Name", sA_Product.BrandID);
            ViewBag.CategoryID = new SelectList(db.SA_Category, "ID", "Name", sA_Product.CategoryID);
            ViewBag.ID = new SelectList(db.SA_Product, "ID", "Name", sA_Product.ID);
            return View(sA_Product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SA_Product sA_Product = db.SA_Product.Find(id);
            if (sA_Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.SA_Brand, "ID", "Name", sA_Product.BrandID);
            ViewBag.CategoryID = new SelectList(db.SA_Category, "ID", "Name", sA_Product.CategoryID);
            ViewBag.ID = new SelectList(db.SA_Product, "ID", "Name", sA_Product.ID);
            return View(sA_Product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CategoryID,BrandID,Name,Description,Price,StockLevel,Active")] SA_Product sA_Product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sA_Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.SA_Brand, "ID", "Name", sA_Product.BrandID);
            ViewBag.CategoryID = new SelectList(db.SA_Category, "ID", "Name", sA_Product.CategoryID);
            ViewBag.ID = new SelectList(db.SA_Product, "ID", "Name", sA_Product.ID);
            return View(sA_Product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SA_Product sA_Product = db.SA_Product.Find(id);
            if (sA_Product == null)
            {
                return HttpNotFound();
            }
            return View(sA_Product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SA_Product sA_Product = db.SA_Product.Find(id);
            db.SA_Product.Remove(sA_Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
