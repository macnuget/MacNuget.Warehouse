using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacNuget.Warehouse.ApplicationCore.Interfaces.Repositories;
using MacNuget.Warehouse.ApplicationCore.Interfaces.Services;
using MacNuget.Warehouse.Domain.Models;

namespace MacNuget.Warehouse.ApplicationCore.Services
{
    public class RefillsService : IRefillsService
    {
        private readonly IRefillsRepository _refillsRepository;

        public RefillsService(IRefillsRepository refillsRepository)
        {
            _refillsRepository = refillsRepository;
        }

        public async Task<IEnumerable<Refill>> GetAllRefills()
        {
            var list = await _refillsRepository.GetAll();
            return list;
        }

        public async Task<Refill> GetRefill(int id)
        {
            var refill = await _refillsRepository.Get(id);
            return refill;
        }

        public async Task<Refill> InsertRefill(Refill entity)
        {
            var id = await _refillsRepository.Insert(entity);
            return await _refillsRepository.Get(id);
        }

        public async Task<Refill> UpdateRefill(Refill entity)
        {
            await _refillsRepository.Update(entity);
            return await (_refillsRepository.Get(entity.Id));
        }

        public async Task<Refill> DeleteRefill(int id)
        {
            var item = await (_refillsRepository.Get(id));
            await _refillsRepository.Delete(id);
            return item;
        }
    }
}
