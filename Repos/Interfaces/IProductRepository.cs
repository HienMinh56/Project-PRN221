using BOs.Entities;

using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product, IFormFile image, Microsoft.AspNetCore.Hosting.IHostingEnvironment enviroment);
        public void DeleteProduct(string productId);
        public Product GetProductById(string productId);
        public List<Product> GetProducts();
        public Task<Product> UpdateProduct(string productId, Product product, IFormFile image, Microsoft.AspNetCore.Hosting.IHostingEnvironment enviroment);
    }
}