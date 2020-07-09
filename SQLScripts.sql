-- Create Product Database
GO
CREATE TABLE Product (
    [Id] int IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(60) NOT NULL,
    [Price] DECIMAL(12,2) NOT NULL,
    [Image] VARCHAR(255) NOT NULL
);
GO

INSERT INTO Product (Name, Price, Image) VALUES ('Camiseta Colored Book', 39.90, 'camiseta-colored-book.jpg');
INSERT INTO Product (Name, Price, Image) VALUES ('Camiseta Desaparecendo', 39.90, 'camiseta-desaparecendo.jpg');
INSERT INTO Product (Name, Price, Image) VALUES ('Camiseta Freedie Forever', 59.90, 'camiseta-freedie-forever.jpg');
INSERT INTO Product (Name, Price, Image) VALUES ('Camiseta Patones', 39.90, 'camiseta-patones.jpg');
INSERT INTO Product (Name, Price, Image) VALUES ('Camiseta Psicose Galatica', 49.90, 'camiseta-psicose-galatica.jpg');
INSERT INTO Product (Name, Price, Image) VALUES ('Camiseta Tonight Will Have Moonlight', 39.90, 'camiseta-tonight-will-have-moonlight.jpg');