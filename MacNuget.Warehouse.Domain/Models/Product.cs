namespace MacNuget.Warehouse.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; } = 0;
        public bool Available { get; set; } = false;

    }
}
