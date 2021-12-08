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

        public IEnumerable<Refill> GetAll()
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return DB.QueryAll<Refill>();
        }

        public Refill Get(int id)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return DB.Query<Refill>(r => r.Id == id).FirstOrDefault();
        }

        public int Insert(Refill entity)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return DB.Insert<Refill, int>(entity);
        }

        public void Update(Refill entity)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            DB.Update<Refill>(entity);
        }

        public void Delete(int id)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            DB.Delete<Refill>(r => r.Id == id);
        }

        public long Count()
        {
            throw new NotImplementedException();
        }
    }
}
