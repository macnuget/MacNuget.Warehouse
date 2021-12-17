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

    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly IConfiguration _configuration;

        public SuppliersRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return await DB.QueryAllAsync<Supplier>();
        }

        public async Task<Supplier> Get(string id)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return (await DB.QueryAsync<Supplier>(s => s.VatNumber == id)).FirstOrDefault();
        }

        public async Task<string> Insert(Supplier entity)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return await DB.InsertAsync<Supplier, string>(entity);
        }

        public async Task Update(Supplier entity)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            await DB.UpdateAsync<Supplier>(entity);
        }

        public async Task Delete(string id)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            await DB.DeleteAsync<Supplier>(s => s.VatNumber == id);
        }

        
    }
}
