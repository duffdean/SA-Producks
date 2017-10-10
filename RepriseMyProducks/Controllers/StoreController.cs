using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Producks.Model;
using System.Net.Http;

namespace RepriseMyProducks.Controllers
{
    public class StoreController : Controller
    {
        private StoreDb db = new StoreDb();

        // GET: Store
        public ActionResult Index()
        {
            var res = from s in db.Products
                      join c in db.Brands on s.Brand.Id equals c.Id
                      select s;

            List<ViewModels.Category> categoryVM = db.Categories
                .Where(c => c.Active == true)
                .Select(c => new ViewModels.Category
                {
                    Name = c.Name,
                    Description = c.Description
                }).ToList();



            //List<ViewModels.Product> productVM = db.Products
            //    .Include(p => p.Brand)
            //    .Include(p => p.Category)
            //    .Where(p => p.Active == true)
            //    .Select(p => new ViewModels.Product
            //    {
            //        Active = p.Active,
            //        Brand = new ViewModels.Brand
            //        {
            //            Active = p.Brand.Active,
            //            Name = p.Brand.Name
            //        },
            //        Category = new ViewModels.Category
            //        {
            //            Active = p.Category.Active,
            //            Name = p.Category.Name
            //        },
            //        Name = p.Name,
            //        Price = p.Price,
            //        StockLevel = p.StockLevel
            //    }).ToList();

            //var products = db.Products.Include(p => p.Brand).Include(p => p.Category);
            return View(categoryVM);
        }

        public ActionResult ProductByCategories(String categoryName)
        {
            List<ViewModels.Product> productVM;
            HttpClient sClient = new HttpClient();
            IEnumerable<Product> apiProd = new List<Product>();
            sClient.BaseAddress = new System.Uri("http://undercutters.azurewebsites.net");
            int catId = 0;

            if (categoryName != null)
            {
                catId = db.Categories
                .Where(c => c.Name == categoryName)
                .Select(c => c.Id)
                .FirstOrDefault();

                productVM = db.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Where(p => p.Active == true &&
                        p.StockLevel > 0)
                .Select(p => new ViewModels.Product
                {
                    Brand = new ViewModels.Brand
                    {
                        Active = p.Brand.Active,
                        Name = p.Brand.Name
                    },
                    Category = new ViewModels.Category
                    {
                        Active = p.Category.Active,
                        Name = p.Category.Name
                    },
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description
                })
                .Where(p => p.Category.Name == categoryName).ToList();
            }
            else
            {
                productVM = db.Products
               .Include(p => p.Brand)
               .Include(p => p.Category)
               .Where(p => p.Active == true &&
                        p.StockLevel > 0)
               .Select(p => new ViewModels.Product
               {
                   Brand = new ViewModels.Brand
                   {
                       Active = p.Brand.Active,
                       Name = p.Brand.Name
                   },
                   Category = new ViewModels.Category
                   {
                       Active = p.Category.Active,
                       Name = p.Category.Name
                   },
                   Name = p.Name,
                   Price = p.Price,
                   Description = p.Description
               }).ToList();
            }

            sClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            HttpResponseMessage response = sClient.GetAsync("api/Product").Result;
            if (response.IsSuccessStatusCode)
            {
                apiProd = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;

            }

            foreach (Product product in apiProd)
            {
                if (categoryName != null)
                {
                    if (!productVM.Any(p => p.Name == product.Name) && product.CategoryId == catId)
                    {
                        productVM.Add(new ViewModels.Product
                        {
                            Name = product.Name,
                            Description = product.Description,
                            Price = product.Price
                        }
                        );
                    }
                }
                else
                {
                    if (!productVM.Any(p => p.Name == product.Name))
                    {
                        productVM.Add(new ViewModels.Product
                        {
                            Name = product.Name,
                            Description = product.Description,
                            Price = product.Price
                        }
                        );
                    }
                }
            }

            return View(productVM);
        }

        public ActionResult Products(Int32 Id)
        {
            return View(db.Products.ToList());
        }
    }
}