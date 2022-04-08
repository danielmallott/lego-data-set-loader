using CsvHelper.Configuration;
using LegoDataSetLoader.Data.Models;

namespace LegoDataSetLoader.Program.CsvMappers;

public class PartCategoriesMap : ClassMap<PartCategory>
{
    public PartCategoriesMap()
    {
        Map(m => m.PartCategoryId).Name("id");
        Map(m => m.PartCategoryName).Name("name");
    }
}