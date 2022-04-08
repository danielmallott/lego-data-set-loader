using CsvHelper.Configuration;
using LegoDataSetLoader.Data.Models;
using LegoDataSetLoader.Program.TypeConverters;

namespace LegoDataSetLoader.Program.CsvMappers;

public class ColorsMap : ClassMap<Color>
{
    public ColorsMap()
    {
        Map(m => m.ColorId).Name("id");
        Map(m => m.ColorName).Name("name");
        Map(m => m.Rgb).Name("rgb");
        Map(m => m.IsTrans).Name("is_trans").TypeConverter<BooleanTypeConverter>();
    }
}