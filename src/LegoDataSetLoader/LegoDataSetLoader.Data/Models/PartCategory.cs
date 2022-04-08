using System;
using System.Collections.Generic;

namespace LegoDataSetLoader.Data.Models
{
    public partial class PartCategory
    {
        public PartCategory()
        {
            Parts = new HashSet<Part>();
        }

        public int PartCategoryId { get; set; }
        public string PartCategoryName { get; set; } = null!;

        public virtual ICollection<Part> Parts { get; set; }
    }
}
