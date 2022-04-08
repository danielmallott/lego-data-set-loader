CREATE TABLE dbo.Elements (
    ElementId VARCHAR(10) NOT NULL CONSTRAINT PK_Elements PRIMARY KEY CLUSTERED,
    PartNumber VARCHAR(20) NOT NULL CONSTRAINT FK_Elements_Parts FOREIGN KEY REFERENCES dbo.Parts(PartNumber),
    ColorId INT NOT NULL CONSTRAINT FK_Elements_Colors FOREIGN KEY REFERENCES dbo.Colors(ColorId)
);