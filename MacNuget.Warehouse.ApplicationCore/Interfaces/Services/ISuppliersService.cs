namespace MacNuget.Warehouse.ApplicationCore.Interfaces.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MacNuget.Warehouse.Domain.Models;

    public interface ISuppliersService
    {
        Task<IEnumerable<Supplier>> GetAllSuppliers();
        Task<Supplier> GetSupplier(string id);
        Task<Supplier> InsertSupplier(Supplier entity);
        Task<Supplier> UpdateSupplier(Supplier entity);
        Task<Supplier> DeleteSupplier(string id);
    }
}
