using CsvHelper.Configuration;
using LegoDataSetLoader.Data.Models;

namespace LegoDataSetLoader.Program.CsvMappers;

public class PartsMap : ClassMap<Part>
{
    public PartsMap()
    {
        Map(m => m.PartNumber).Name("part_num");
        Map(m => m.PartName).Name("name");
        Map(m => m.PartCategoryId).Name("part_cat_id");
        Map(m => m.Material).Name("part_material");
    }
}