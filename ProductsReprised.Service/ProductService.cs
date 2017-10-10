using ProductsReprised.Core.Models;
using ProductsReprised.Data.Interfaces;
using ProductsReprised.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsReprised.Service
{
    public class ProductService : IProductService
    {
        private IRepository<Product> productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public IQueryable<Product> GetProducts()
        {
            return productRepository.GetAll;
        }

        public Product GetProduct(int id)
        {
            return productRepository.GetById(id);
        }

        public void AddProduct(Product product)
        {
            productRepository.Insert(product);
        }

        public void UpdateProduct(Product product)
        {
            productRepository.Update(product);
        }

        public void DeleteProduct(Product product)
        {
            productRepository.Delete(product);
        }
    }
}