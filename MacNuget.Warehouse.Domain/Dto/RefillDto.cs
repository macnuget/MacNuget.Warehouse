using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacNuget.Warehouse.Domain.Dto
{
    public class RefillDto
    {
        public int Id { get; set; }
        public string SupplierId { get; set; }
        public DateTime ArriveDate { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
