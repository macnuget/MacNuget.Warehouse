namespace MacNuget.Warehouse.ApplicationCore.Interfaces.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MacNuget.Warehouse.Domain.Models;

    public interface IProductsService 
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProduct(int id);
        Task<int> InsertProduct(Product entity);
        Task<Product> UpdateProduct(Product entity);
        Task<Product> DeleteProduct(int id);
    }
}
