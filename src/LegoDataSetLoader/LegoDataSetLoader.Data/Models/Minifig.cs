using System;
using System.Collections.Generic;

namespace LegoDataSetLoader.Data.Models
{
    public partial class Minifig
    {
        public string MinifigNumber { get; set; } = null!;
        public string MinifigName { get; set; } = null!;
        public int NumberOfParts { get; set; }
    }
}
