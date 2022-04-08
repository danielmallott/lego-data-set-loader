using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace LegoDataSetLoader.Program.TypeConverters;

public class BooleanTypeConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
        return text.ToLowerInvariant() == "t";
    }

    public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
    {
        bool? valueAsBool = value as bool?;
        return valueAsBool.HasValue && valueAsBool.Value ? "t" : "f";
    }
}