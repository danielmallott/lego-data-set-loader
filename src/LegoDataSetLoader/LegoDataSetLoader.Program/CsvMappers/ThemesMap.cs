using CsvHelper.Configuration;
using LegoDataSetLoader.Data.Models;

namespace LegoDataSetLoader.Program.CsvMappers;

public class ThemesMap : ClassMap<Theme>
{
    public ThemesMap()
    {
        Map(m => m.ThemeId).Name("id");
        Map(m => m.ThemeName).Name("name");
        Map(m => m.ParentThemeId).Name("parent_id");
    }
}