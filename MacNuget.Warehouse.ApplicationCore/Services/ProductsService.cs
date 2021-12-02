namespace MacNuget.Warehouse.ApplicationCore.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MacNuget.Warehouse.ApplicationCore.Interfaces.Repositories;
    using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
    using MacNuget.Warehouse.Domain.Models;

    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var list = _productsRepository.GetAll();
            return list;
        }

        public Product GetProduct(int id)
        {
            var product = _productsRepository.Get(id);
            return product;
        }

        public void InsertProduct(Product entity)
        {
            _productsRepository.Insert(entity);
        }

        public void UpdateProduct(Product entity)
        {
            _productsRepository.Update(entity);
        }

        public void DeleteProduct(int id)
        {
            _productsRepository.Delete(id);
        }
    }
}
