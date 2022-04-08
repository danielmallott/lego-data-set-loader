using CsvHelper.Configuration;
using LegoDataSetLoader.Data.Models;

namespace LegoDataSetLoader.Program.CsvMappers;

public class InventorySetsMap : ClassMap<InventorySet>
{
    public InventorySetsMap()
    {
        Map(m => m.InventoryId).Name("inventory_id");
        Map(m => m.Quantity).Name("quantity");
        Map(m => m.SetNumber).Name("set_num");
    }
}