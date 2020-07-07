-- Create Product Database
GO
CREATE TABLE Product (
    [Id] int IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(60) NOT NULL,
    [Price] DECIMAL(12,2) NOT NULL,
    [Image] IMAGE
);
GO

INSERT INTO Product (Name, Price) 
VALUES (
    'Camiseta Homem de Ferro', 
    39.90
    );