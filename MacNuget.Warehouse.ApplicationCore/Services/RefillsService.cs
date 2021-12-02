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

        public IEnumerable<Refill> GetAllRefills()
        {
            var list = _refillsRepository.GetAll();
            return list;
        }

        public Refill GetRefill(int id)
        {
            var refill = _refillsRepository.Get(id);
            return refill;
        }

        public void InsertRefill(Refill entity)
        {
            _refillsRepository.Insert(entity);
        }

        public void UpdateRefill(Refill entity)
        {
            _refillsRepository.Update(entity);
        }

        public void DeleteRefill(int id)
        {
            _refillsRepository.Delete(id);
        }
    }
}
