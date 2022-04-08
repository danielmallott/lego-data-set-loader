using System;
using System.Collections.Generic;

namespace LegoDataSetLoader.Data.Models
{
    public partial class Element
    {
        public string ElementId { get; set; } = null!;
        public string PartNumber { get; set; } = null!;
        public int ColorId { get; set; }

        public virtual Color Color { get; set; } = null!;
        public virtual Part PartNumberNavigation { get; set; } = null!;
    }
}
