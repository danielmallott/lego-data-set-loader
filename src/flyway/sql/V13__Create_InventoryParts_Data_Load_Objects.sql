CREATE SCHEMA DataLoad AUTHORIZATION dbo;
GO

CREATE TYPE DataLoad.InventoryParts AS TABLE (
    InventoryId INT,
    PartNumber VARCHAR(20),
    ColorId INT,
    Quantity INT,
    IsSpare BIT
);
GO

CREATE PROCEDURE DataLoad.LoadInventoryParts
    @data DataLoad.InventoryParts READONLY
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.InventoryParts
        (
            InventoryId,
            PartNumber,
            ColorId,
            Quantity,
            IsSpare
        )
    SELECT InventoryId
        ,PartNumber
        ,ColorId
        ,Quantity
        ,IsSpare
    FROM @data;
END;
GO

CREATE PROCEDURE DataLoad.UpdateInventoryParts
    @data DataLoad.InventoryParts READONLY
AS
BEGIN  
    SET NOCOUNT ON;

    UPDATE eip
    SET eip.Quantity = nip.Quantity
    FROM dbo.InventoryParts eip
        INNER JOIN @data nip 
            ON eip.InventoryId = nip.InventoryId
                AND eip.PartNumber = nip.PartNumber
                AND eip.ColorId = nip.ColorId
                AND eip.IsSpare = nip.IsSpare;
END;
GO