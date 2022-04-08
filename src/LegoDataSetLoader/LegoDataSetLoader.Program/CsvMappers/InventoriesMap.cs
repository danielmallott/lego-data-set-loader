using CsvHelper.Configuration;
using LegoDataSetLoader.Data.Models;

namespace LegoDataSetLoader.Program.CsvMappers;

public class InventoriesMap : ClassMap<Inventory>
{
    public InventoriesMap()
    {
        Map(m => m.InventoryId).Name("id");
        Map(m => m.SetNumber).Name("set_num");
        Map(m => m.InventoryVersion).Name("version");
    }
}