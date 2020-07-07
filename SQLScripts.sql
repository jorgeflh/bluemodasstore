-- Create Product Database
GO
CREATE TABLE Product (
    [Id] int IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(60) NOT NULL,
    [Description] VARCHAR(255) NOT NULL,
    [Price] DECIMAL(12,2) NOT NULL,
    [Image] IMAGE
);
GO

INSERT INTO Product (Name, Description, Price) 
VALUES (
    'Camiseta Homem de Ferro', 
    'Camiseta da coleção Avengers 100% Algodão',
    39.90
    );