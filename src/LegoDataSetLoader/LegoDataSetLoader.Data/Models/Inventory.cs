using System;
using System.Collections.Generic;

namespace LegoDataSetLoader.Data.Models
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int InventoryVersion { get; set; }
        public string SetNumber { get; set; } = null!;

        public virtual Set SetNumberNavigation { get; set; } = null!;
    }
}
