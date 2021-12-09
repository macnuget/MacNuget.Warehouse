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

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            var list = await _suppliersRepository.GetAll();
            return list;
        }

        public async Task<Supplier> GetSupplier(string id)
        {
            var supplier = await _suppliersRepository.Get(id);
            return supplier;
        }

        public async Task<Supplier> InsertSupplier(Supplier entity)
        {
            var id = await _suppliersRepository.Insert(entity);
            return await _suppliersRepository.Get(id);
        }

        public async Task<Supplier> UpdateSupplier(Supplier entity)
        {
            await _suppliersRepository.Update(entity);
            return await _suppliersRepository.Get(entity.VatNumber);
        }

        public async Task<Supplier> DeleteSupplier(string id)
        {
            await _suppliersRepository.Delete(id);
            return await _suppliersRepository.Get(id);
        }
    }
}
