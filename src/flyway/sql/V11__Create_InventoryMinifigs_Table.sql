CREATE TABLE dbo.InventoryMinifigs (
    InventoryId INT NOT NULL CONSTRAINT FK_InventoryMinifigs_Inventories FOREIGN KEY REFERENCES dbo.Inventories(InventoryId),
    MinifigNumber VARCHAR(20) NOT NULL CONSTRAINT FK_InventoryMinifigs_Minifigs FOREIGN KEY REFERENCES dbo.Minifigs(MinifigNumber),
    Quantity INT NULL
);