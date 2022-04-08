using CsvHelper.Configuration;
using LegoDataSetLoader.Data.Models;

namespace LegoDataSetLoader.Program.CsvMappers;

public class ElementsMap : ClassMap<Element>
{
    public ElementsMap()
    {
        Map(m => m.ElementId).Name("element_id");
        Map(m => m.ColorId).Name("color_id");
        Map(m => m.PartNumber).Name("part_num");
    }
}