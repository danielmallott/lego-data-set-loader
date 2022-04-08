CREATE TABLE dbo.InventorySets (
    InventoryId INT NOT NULL CONSTRAINT FK_InventorySets_Inventories FOREIGN KEY REFERENCES dbo.Inventories(InventoryId),
    SetNumber VARCHAR(20) NOT NULL CONSTRAINT FK_InventorySets_Sets FOREIGN KEY REFERENCES dbo.Sets(SetNumber),
    Quantity INT NULL
);