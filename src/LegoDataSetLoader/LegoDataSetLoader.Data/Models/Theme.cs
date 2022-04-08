using System;
using System.Collections.Generic;

namespace LegoDataSetLoader.Data.Models
{
    public partial class Theme
    {
        public Theme()
        {
            InverseParentTheme = new HashSet<Theme>();
            Sets = new HashSet<Set>();
        }

        public int ThemeId { get; set; }
        public string ThemeName { get; set; } = null!;
        public int? ParentThemeId { get; set; }

        public virtual Theme? ParentTheme { get; set; }
        public virtual ICollection<Theme> InverseParentTheme { get; set; }
        public virtual ICollection<Set> Sets { get; set; }
    }
}
