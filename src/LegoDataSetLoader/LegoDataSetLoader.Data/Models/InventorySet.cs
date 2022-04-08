using System;
using System.Collections.Generic;

namespace LegoDataSetLoader.Data.Models
{
    public partial class InventorySet
    {
        public int InventoryId { get; set; }
        public string SetNumber { get; set; } = null!;
        public int? Quantity { get; set; }

        public virtual Inventory Inventory { get; set; } = null!;
        public virtual Set SetNumberNavigation { get; set; } = null!;
    }
}
