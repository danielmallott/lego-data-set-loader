using CsvHelper.Configuration;
using LegoDataSetLoader.Data.Models;

namespace LegoDataSetLoader.Program.CsvMappers;

public class SetsMap : ClassMap<Set>
{
    public SetsMap()
    {
        Map(m => m.SetNumber).Name("set_num");
        Map(m => m.SetName).Name("name");
        Map(m => m.ReleaseYear).Name("year");
        Map(m => m.ThemeId).Name("theme_id");
        Map(m => m.NumberOfParts).Name("num_parts");
    }
}