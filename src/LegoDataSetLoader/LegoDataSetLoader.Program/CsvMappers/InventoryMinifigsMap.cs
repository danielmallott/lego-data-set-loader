using CsvHelper.Configuration;
using LegoDataSetLoader.Data.Models;

namespace LegoDataSetLoader.Program.CsvMappers;

public class InventoryMinifigsMap : ClassMap<InventoryMinifig>
{
    public InventoryMinifigsMap()
    {
        Map(m => m.InventoryId).Name("inventory_id");
        Map(m => m.Quantity).Name("quantity");
        Map(m => m.MinifigNumber).Name("fig_num");
    }
}