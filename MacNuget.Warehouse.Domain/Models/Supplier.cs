using RepoDb.Attributes;

namespace MacNuget.Warehouse.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Map("Suppliers")]
    public class Supplier
    {
        public string VatNumber { get; set; }
        public string Denomination { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
