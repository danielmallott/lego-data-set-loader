using System;
using System.Collections.Generic;

namespace LegoDataSetLoader.Data.Models
{
    public partial class InventoryMinifig
    {
        public int InventoryId { get; set; }
        public string MinifigNumber { get; set; } = null!;
        public int? Quantity { get; set; }

        public virtual Inventory Inventory { get; set; } = null!;
        public virtual Minifig MinifigNumberNavigation { get; set; } = null!;
    }
}
