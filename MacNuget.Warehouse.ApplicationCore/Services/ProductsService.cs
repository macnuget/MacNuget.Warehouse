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

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var list = await _productsRepository.GetAll();
            return list;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _productsRepository.Get(id);
            return product;
        }

        
        public async Task<Product> UpdateProduct(Product entity)
        {
            await _productsRepository.Update(entity);
            var product = await _productsRepository.Get(entity.Id);
            return product;
        }

        public async Task<Product> InsertProduct(Product entity)
        {
            var id = await _productsRepository.Insert(entity);
            return await _productsRepository.Get(id);
        }

        public async Task<Product> DeleteProduct(int id)
        {
            await _productsRepository.Delete(id);
            return await _productsRepository.Get(id);
        }

    }
}
