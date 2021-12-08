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
        IEnumerable<Supplier> GetAllSuppliers();
        Supplier GetSupplier(string id);
        string InsertSupplier(Supplier entity);
        void UpdateSupplier(Supplier entity);
        void DeleteSupplier(string id);
    }
}
