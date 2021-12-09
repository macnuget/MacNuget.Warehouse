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

    public class RefillsRepository : IRefillsRepository
    {
        private readonly IConfiguration _configuration;

        public RefillsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Refill>> GetAll()
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return await DB.QueryAllAsync<Refill>();
        }

        public async Task<Refill> Get(int id)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return (await DB.QueryAsync<Refill>(r => r.Id == id)).FirstOrDefault();
        }

        public async Task<int> Insert(Refill entity)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return await DB.InsertAsync<Refill, int>(entity);
        }

        public async Task Update(Refill entity)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            await DB.UpdateAsync<Refill>(entity);
        }

        public async Task Delete(int id)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            await DB.DeleteAsync<Refill>(r => r.Id == id);
        }

        
    }
}
