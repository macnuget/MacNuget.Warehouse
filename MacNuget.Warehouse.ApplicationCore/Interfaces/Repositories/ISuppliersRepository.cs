namespace MacNuget.Warehouse.ApplicationCore.Interfaces.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MacNuget.Warehouse.Domain.Models;

    public interface ISuppliersRepository : IRepositoryBase<Supplier, string>
    {
    }
}
