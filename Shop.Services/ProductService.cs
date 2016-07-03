#region

using System.Collections.Generic;
 
using Shop.Repository.Models;
 
using Repository.Pattern.Repositories;
using Service.Pattern;
using System.Linq;
using Shop.Entities;
#endregion

namespace Shop.Services
{
    public interface IProductService : IService<Product>
    {
        Product GetProductById(int id);
        IEnumerable<Product> GetProductByName(string productName);
        IEnumerable<Product> GetProductByBrand();
        IEnumerable<Product> GetProductByFilter();
        IEnumerable<Product> GetProducts(int pageNo, int pageSize);
    }

    public class ProductService : Service<Product>, IProductService
    {
        IRepositoryAsync<Product> _productRepository;
        public ProductService(IRepositoryAsync<Product> repository) : base(repository)
        {
            _productRepository = repository;
        }

        public Product GetProductById(int id)
        {
            //_customerService.Queryable().Where(t => t.CustomerID == key)
            return _productRepository.Queryable().Where(x => x.ProductID == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductByName(string productName)
        {
            //throw new System.NotImplementedException();
            return _productRepository.Queryable().Where(x => x.ProductName == productName);
        }

        public IEnumerable<Product> GetProductByBrand()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetProductByFilter()
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<Product> GetProducts(int pageNo, int pageSize)
        {
           // _productRepository.Queryable();
            throw new System.NotImplementedException();
        }
    }
}