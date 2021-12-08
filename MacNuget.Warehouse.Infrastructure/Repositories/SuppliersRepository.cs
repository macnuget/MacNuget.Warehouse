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

        public IEnumerable<Supplier> GetAll()
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return DB.QueryAll<Supplier>();
        }

        public Supplier Get(string id)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return DB.Query<Supplier>(s => s.VatNumber == id).FirstOrDefault();
        }

        public string Insert(Supplier entity)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            return DB.Insert<Supplier, string>(entity);
        }

        public void Update(Supplier entity)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            DB.Update<Supplier>(entity);
        }

        public void Delete(string id)
        {
            var cs = _configuration.GetConnectionString("WarehouseDB");
            using var DB = new NpgsqlConnection(cs);
            DB.Delete<Supplier>(s => s.VatNumber == id);
        }

        public long Count()
        {
            throw new NotImplementedException();
        }
    }
}
