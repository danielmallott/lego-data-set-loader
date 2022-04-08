CREATE TABLE dbo.PartRelationships (
    RelationshipType CHAR(1) NOT NULL,
    ChildPartNumber VARCHAR(20) NOT NULL CONSTRAINT FK_PartRelationships_PartsChild FOREIGN KEY REFERENCES dbo.Parts(PartNumber),
    ParentPartNumber VARCHAR(20) NOT NULL CONSTRAINT FK_PartRelationships_PartsParent FOREIGN KEY REFERENCES dbo.Parts(PartNumber)
);