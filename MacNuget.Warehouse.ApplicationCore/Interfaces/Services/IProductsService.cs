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
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        int InsertProduct(Product entity);
        void UpdateProduct(Product entity);
        void DeleteProduct(int id);
    }
}
