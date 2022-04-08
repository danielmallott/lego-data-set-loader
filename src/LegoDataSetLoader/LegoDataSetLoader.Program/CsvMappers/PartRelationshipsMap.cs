using CsvHelper.Configuration;
using LegoDataSetLoader.Data.Models;

namespace LegoDataSetLoader.Program.CsvMappers;

public class PartRelationshipsMap : ClassMap<PartRelationship>
{
    public PartRelationshipsMap()
    {
        Map(m => m.ChildPartNumber).Name("child_part_num");
        Map(m => m.ParentPartNumber).Name("parent_part_num");
        Map(m => m.RelationshipType).Name("rel_type");
    }
}