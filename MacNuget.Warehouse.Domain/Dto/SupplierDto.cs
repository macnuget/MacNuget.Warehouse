using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacNuget.Warehouse.Domain.Dto
{
    public class SupplierDto
    {
        public string VatNumber { get; set; }
        public string Denomination { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
