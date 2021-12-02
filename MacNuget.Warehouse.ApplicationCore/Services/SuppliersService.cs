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

    public class SuppliersService : ISuppliersService
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public SuppliersService(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            var list = _suppliersRepository.GetAll();
            return list;
        }

        public Supplier GetSupplier(string id)
        {
            var supplier = _suppliersRepository.Get(id);
            return supplier;
        }

        public void InsertSupplier(Supplier entity)
        {
            _suppliersRepository.Insert(entity);
        }

        public void UpdateSupplier(Supplier entity)
        {
            _suppliersRepository.Update(entity);
        }

        public void DeleteSupplier(string id)
        {
            _suppliersRepository.Delete(id);
        }
    }
}
