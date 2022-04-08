using System;
using System.Collections.Generic;

namespace LegoDataSetLoader.Data.Models
{
    public partial class Set
    {
        public Set()
        {
            Inventories = new HashSet<Inventory>();
        }

        public string SetNumber { get; set; } = null!;
        public string SetName { get; set; } = null!;
        public string ReleaseYear { get; set; } = null!;
        public int ThemeId { get; set; }
        public int NumberOfParts { get; set; }

        public virtual Theme Theme { get; set; } = null!;
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
