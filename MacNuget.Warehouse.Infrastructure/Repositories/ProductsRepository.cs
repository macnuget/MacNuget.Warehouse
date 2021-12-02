namespace MacNuget.Warehouse.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MacNuget.Warehouse.ApplicationCore.Interfaces.Repositories;
    using MacNuget.Warehouse.Domain.Models;
    using Microsoft.Extensions.Configuration;
    using Npgsql;
    using RepoDb;

    public class ProductsRepository : IProductsRepository
    {
        private readonly IConfiguration _configuration;

        public ProductsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Product> GetAll()
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return DB.QueryAll<Product>();
        }

        public Product Get(int id)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return DB.Query<Product>(p => p.Id == id).FirstOrDefault();
        }

        public void Insert(Product entity)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            DB.Insert<Product>(entity);
        }

        public void Update(Product entity)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            DB.Update<Product>(entity);
        }

        public void Delete(int id)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            DB.Delete<Product>(p => p.Id == id);
        }

        public long Count()
        {
            throw new NotImplementedException();
        }
    }
}
