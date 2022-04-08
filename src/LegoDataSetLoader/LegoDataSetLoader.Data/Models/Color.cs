using System;
using System.Collections.Generic;

namespace LegoDataSetLoader.Data.Models
{
    public partial class Color
    {
        public Color()
        {
            Elements = new HashSet<Element>();
        }

        public int ColorId { get; set; }
        public string ColorName { get; set; } = null!;
        public string Rgb { get; set; } = null!;
        public bool IsTrans { get; set; }

        public virtual ICollection<Element> Elements { get; set; }
    }
}
