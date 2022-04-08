CREATE TABLE dbo.Minifigs (
    MinifigNumber VARCHAR(20) NOT NULL CONSTRAINT PK_Minifigs PRIMARY KEY clustered,
    MinifigName VARCHAR(256) NOT NULL,
    NumberOfParts INT NOT NULL
);