
CREATE TABLE Categorie
(
	[CategorieId] INT NOT NULL IDENTITY(1,1),
	[Nom] VARCHAR(25) NOT NULL,

	CONSTRAINT PK_CategorieID PRIMARY KEY (CategorieId)
);
GO
CREATE TABLE Produit
(
	[ProduitId] INT NOT NULL IDENTITY(1,1),
	[Nom] VARCHAR(25) NOT NULL,
	[Prix] FLOAT NOT NULL,
	[CategorieId] INT NOT NULL,

	CONSTRAINT PK_ProduitID PRIMARY KEY (ProduitId),
	CONSTRAINT FK_CategorieId FOREIGN KEY (CategorieId) REFERENCES Categorie(CategorieId)

);
GO
CREATE TABLE Commande
(
	[CommandId] INT NOT NULL IDENTITY(1,1),
	[Heure] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[Benevol] BIT NOT NULL DEFAULT 0

	CONSTRAINT PK_CommandID PRIMARY KEY (CommandID)

);
GO
CREATE TABLE OrderLine
(
	[CommandId] INT NOT NULL,
	[Quantite] INT NOT NULL,
	[PrixGlobal] FLOAT NOT NULL,
	[ProduitId] INT NOT NULL

	CONSTRAINT FK_CommandId FOREIGN KEY (CommandId) REFERENCES Commande(CommandId),
	CONSTRAINT FK_ProduitId FOREIGN KEY (ProduitId) REFERENCES dbo.Produit(ProduitId)
);
GO

INSERT INTO Categorie (Nom) VALUES ('Biere'),
												('Boissons'),
												('Vins'),
												('Bouffe')


INSERT INTO Caisse.dbo.Produit(Nom,Prix,CategorieId) VALUES ('Carlsberg',2.00,1),
																	 ('Jupiler',1.70,1),
																	 ('Duvel',3.50,1),
																	 ('Beer',3.50,1),
																	 ('BG Beer',2.30,1),
																	 ('Leffe Brune',3.50,1),
																	 ('Leffe Blonde',3.50,1),
																	 ('Chimay Bleu',3.00,1),
																	 ('Hoegarden',2.00,1),
																	 ('Kriek',2.50,1);
INSERT INTO Caisse.dbo.Produit(Nom,Prix,CategorieId) VALUES ('Café',1.60,2),
																	 ('Thé',1.60,2),
																	 ('Coca Cola',1.60,2),
																	 ('Fanta',1.60,2),
																	 ('Sprite',1.60,2),
																	 ('Looza',1.70,2),
																	 ('Eau',1.60,2),
																	 ('Ice Tea',1.60,2),
																	 ('Red Bull',3.00,2),
																	 ('Vin Bouteille',15.00,3),
																	 ('Vin Special (Bout.)',45.00,3),
																	 ('Vin 1/2 bouteille',11.50,3),
																	 ('Verre de vin',3.00,3),
																	 ('Croque Monsieur', 1.50,4),
																	 ('Chips',1.00,4)
