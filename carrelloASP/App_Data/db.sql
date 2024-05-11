/* pulizia di tutte le tabelle per ricrearle da zero */
DROP TABLE IF EXISTS [dbo].[prodotti];
DROP TABLE IF EXISTS [dbo].[categorie];
DROP TABLE IF EXISTS [dbo].[users];
DROP TABLE IF EXISTS [dbo].[carrelli];
DROP TABLE IF EXISTS [dbo].[storico_ordini]


/* creazione delle tabelle */
/* users */
CREATE TABLE [dbo].[users] (
	[id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[username] NVARCHAR(50) NOT NULL,
	[password] NVARCHAR(50) NOT NULL,
	[email] NVARCHAR(50) NOT NULL,
	/* role dev'essere admin, fornitore o user e nessun altro tipo*/
	[role] NVARCHAR(50) NOT NULL CHECK (role IN ('admin', 'fornitore', 'user')),
	[validita] BIT NOT NULL DEFAULT 1
);

/* categorie */
CREATE TABLE [dbo].[categorie] (
	[id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[nome] NVARCHAR(50) NOT NULL,
	[validita] BIT NOT NULL DEFAULT 1
);

/* prodotti */
CREATE TABLE [dbo].[prodotti] (
	[id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[nome] NVARCHAR(50) NOT NULL,
	[descrizione] NVARCHAR(50) NOT NULL,
	[prezzo] DECIMAL(18, 2) NOT NULL,
	[quantita] INT NOT NULL,
	[immagine] NVARCHAR(100) NOT NULL,
	[categoria_id] INT NOT NULL,
	[fornitore_id] INT NOT NULL,
	[validita] BIT NOT NULL DEFAULT 1,
	FOREIGN KEY ([categoria_id]) REFERENCES [categorie]([id]),
	FOREIGN KEY ([fornitore_id]) REFERENCES [users]([id])
);

/* carrello */
CREATE TABLE [dbo].[carrelli] (
	[id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[quantita] INT NOT NULL,
	[prodotto_id] INT NOT NULL,
	[user_id] INT NOT NULL,
	[validita] BIT NOT NULL DEFAULT 1,
	FOREIGN KEY ([prodotto_id]) REFERENCES [prodotti]([id]),
	FOREIGN KEY ([user_id]) REFERENCES [users]([id])
);

/* storico ordini */
CREATE TABLE [dbo].[storico_ordini] (
	[id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[quantita] INT NOT NULL,
	[prodotto_id] INT NOT NULL,
	[user_id] INT NOT NULL,
	[data] DATETIME NOT NULL,
	[validita] BIT NOT NULL DEFAULT 1,
	FOREIGN KEY ([prodotto_id]) REFERENCES [prodotti]([id]),
	FOREIGN KEY ([user_id]) REFERENCES [users]([id])
);

/* azzeramento degli indici */
DBCC CHECKIDENT ('users', RESEED, 0);
DBCC CHECKIDENT ('categorie', RESEED, 0);
DBCC CHECKIDENT ('prodotti', RESEED, 0);
DBCC CHECKIDENT ('carrelli', RESEED, 0);
DBCC CHECKIDENT ('storico_ordini', RESEED, 0)


/* creazione di dati di test */
INSERT INTO [dbo].[users] ([username], [password], [email], [role]) VALUES ('admin', 'admin', 'admin@gmail.com', 'admin');
INSERT INTO [dbo].[users] ([username], [password], [email], [role]) VALUES ('fornitore', 'fornitore', 'fornitore@gmail.com', 'fornitore');
INSERT INTO [dbo].[users] ([username], [password], [email], [role]) VALUES ('user', 'user', 'user@gmail.com', 'user');

INSERT INTO [dbo].[categorie] ([nome]) VALUES ('elettronica');
INSERT INTO [dbo].[categorie] ([nome]) VALUES ('abbigliamento');
INSERT INTO [dbo].[categorie] ([nome]) VALUES ('casa');
