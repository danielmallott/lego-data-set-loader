CREATE TABLE dbo.InventoryParts (
    InventoryId INT NOT NULL CONSTRAINT FK_InventoryParts_Inventory FOREIGN KEY REFERENCES dbo.Inventories(InventoryId),
    PartNumber VARCHAR(20) NOT NULL CONSTRAINT FK_InventoryParts_Parts FOREIGN KEY REFERENCES dbo.Parts(PartNumber),
    ColorId INT NOT NULL CONSTRAINT FK_InventoryParts_Colors FOREIGN KEY REFERENCES dbo.Colors(ColorId),
    Quantity INT NULL,
    IsSpare BIT NULL
);