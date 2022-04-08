using System;
using System.Collections.Generic;

namespace LegoDataSetLoader.Data.Models
{
    public partial class InventoryPart
    {
        public int InventoryId { get; set; }
        public string PartNumber { get; set; } = null!;
        public int ColorId { get; set; }
        public int? Quantity { get; set; }
        public bool? IsSpare { get; set; }

        public virtual Color Color { get; set; } = null!;
        public virtual Inventory Inventory { get; set; } = null!;
        public virtual Part PartNumberNavigation { get; set; } = null!;
    }
}
