using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RepriseMyProducks.Controllers
{
    public class ExportsController : ApiController
    {
        private Producks.Model.StoreDb db = new Producks.Model.StoreDb();

        // GET: api/Brands
        [HttpGet]
        [Route("api/Brands")]
        public IEnumerable<Dtos.Brand> GetBrands()
        {
            return db.Brands
                     .AsEnumerable()
                     .Select(b => new Dtos.Brand
                     {
                         Id = b.Id,
                         Name = b.Name,
                         Active = b.Active
                     });
        }

        // GET: api/Brands
        [HttpGet]
        [Route("api/Categories")]
        public IEnumerable<Dtos.Category> GetCategories()
        {
            return db.Categories
                     .AsEnumerable()
                     .Select(c => new Dtos.Category
                     {
                         Id = c.Id,
                         Name = c.Name,
                         Description = c.Description,
                         Active = c.Active
                     });
        }

        [HttpGet]
        [Route("api/Products")]
        public IEnumerable<Dtos.Product> GetCategories(Int32 categoryId, String brand, double? minPrice, double? maxPrice)
        {
            var products = db.Products
                     .AsEnumerable()
                     .Where(p => p.CategoryId == categoryId ||
                            p.Brand.Equals(brand) || 
                            p.Price > minPrice ||
                            p.Price < maxPrice)

                     .Select(p => new Dtos.Product
                     {
                         Id = p.Id,
                         Name = p.Name,
                         Description = p.Description,
                         Active = p.Active
                     });

            return products;
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