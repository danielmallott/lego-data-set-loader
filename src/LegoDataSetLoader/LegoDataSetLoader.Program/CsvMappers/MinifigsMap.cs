using CsvHelper.Configuration;
using LegoDataSetLoader.Data.Models;

namespace LegoDataSetLoader.Program.CsvMappers;

public class MinifigsMap : ClassMap<Minifig>
{
    public MinifigsMap()
    {
        Map(m => m.MinifigNumber).Name("fig_num");
        Map(m => m.MinifigName).Name("name");
        Map(m => m.NumberOfParts).Name("num_parts");
    }
}