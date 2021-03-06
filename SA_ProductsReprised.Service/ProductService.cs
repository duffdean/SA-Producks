﻿using Newtonsoft.Json;
using SA_ProductsReprised.Repositoty.Interfaces;
using SA_ProductsReprised.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SA_ProductsReprised.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Models.SA_Product> _productRepository;

        public ProductService(IRepository<Models.SA_Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Dto.SA_Product> GetAll()
        {
            var products = _productRepository.GetAll();

            return products.Select(Map);
        }

        public IEnumerable<Dto.SA_Product> GetAllWithUnderCutters()
        {
            var products = _productRepository.GetAll();

            //Need to make these calls to APIs more generic for all services
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri("http://undercutters.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            HttpResponseMessage response = client.GetAsync("api/Product").Result;
            string data = response.Content.ReadAsStringAsync().Result;


            List<Dto.SA_Product> apiProds = JsonConvert.DeserializeObject<List<Dto.SA_Product>>(data);
            IEnumerable<Dto.SA_Product> allProds = products.Select(Map);
            allProds = allProds.ToList().Concat(apiProds);

            return allProds;
        }

        public Dto.SA_Product Get(int id)
        {
            var product = _productRepository.Get(id);

            return product == null ? null : Map(product);
        }

        private static Dto.SA_Product Map(Models.SA_Product product)
        {
            return new Dto.SA_Product
            {
                ID = product.ID,
                Name = product.Name,
                Description = product.Description,
                Active = product.Active,
                BrandID = product.BrandID,
                CategoryID = product.CategoryID
            };
        }
    }
}