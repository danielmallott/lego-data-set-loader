using CsvHelper.Configuration;
using LegoDataSetLoader.Program.PlainTypes;
using LegoDataSetLoader.Program.TypeConverters;

namespace LegoDataSetLoader.Program.CsvMappers;

public class InventoryPartsMap : ClassMap<InventoryPart>
{
    public InventoryPartsMap()
    {
        Map(m => m.InventoryId).Name("inventory_id");
        Map(m => m.ColorId).Name("color_id");
        Map(m => m.IsSpare).Name("is_spare").TypeConverter<BooleanTypeConverter>();
        Map(m => m.PartNumber).Name("part_num");
        Map(m => m.Quantity).Name("quantity");
    }
}