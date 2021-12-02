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
        IEnumerable<Refill> GetAllRefills();
        Refill GetRefill(int id);
        void InsertRefill(Refill entity);
        void UpdateRefill(Refill entity);
        void DeleteRefill(int id);
    }
}
