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

        public async Task<IEnumerable<Product>> GetAll()
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return await DB.QueryAllAsync<Product>();
        }

        public async Task<Product> Get(int id)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return (await DB.QueryAsync<Product>(p => p.Id == id)).FirstOrDefault();
        }

        public async Task<int> Insert(Product entity)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return await DB.InsertAsync<Product, int>(entity);
        }

        public async Task Update(Product entity)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            await DB.UpdateAsync<Product>(entity);
        }

        public async Task Delete(int id)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            await DB.DeleteAsync<Product>(p => p.Id == id);
        }

    }
}
