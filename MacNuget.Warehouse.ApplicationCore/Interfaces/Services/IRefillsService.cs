namespace MacNuget.Warehouse.ApplicationCore.Interfaces.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MacNuget.Warehouse.Domain.Models;

    public interface IRefillsService
    {
        Task<IEnumerable<Refill>> GetAllRefills();
        Task<Refill> GetRefill(int id);
        Task<int> InsertRefill(Refill entity);
        Task<Refill> UpdateRefill(Refill entity);
        Task<Refill> DeleteRefill(int id);
    }
}
