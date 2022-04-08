using System;
using System.Collections.Generic;

namespace LegoDataSetLoader.Data.Models
{
    public partial class PartRelationship
    {
        public string RelationshipType { get; set; } = null!;
        public string ChildPartNumber { get; set; } = null!;
        public string ParentPartNumber { get; set; } = null!;

        public virtual Part ChildPartNumberNavigation { get; set; } = null!;
        public virtual Part ParentPartNumberNavigation { get; set; } = null!;
    }
}
