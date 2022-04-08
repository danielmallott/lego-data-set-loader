using System;
using System.Collections.Generic;

namespace LegoDataSetLoader.Data.Models
{
    public partial class Part
    {
        public Part()
        {
            Elements = new HashSet<Element>();
        }

        public string PartNumber { get; set; } = null!;
        public string PartName { get; set; } = null!;
        public int PartCategoryId { get; set; }
        public string Material { get; set; }

        public virtual PartCategory PartCategory { get; set; } = null!;
        public virtual ICollection<Element> Elements { get; set; }
    }
}
