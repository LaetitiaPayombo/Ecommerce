Drop TABLE client;
Drop TABLE produit;
Drop TABLE compte;
Drop TABLE panier;

CREATE TABLE [dbo].[client]
(
	[id] INT IDENTITY (1, 1) NOT NULL, 
	[prenom] VARCHAR(50) NOT NULL, 
    [nom] VARCHAR(50) NOT NULL, 
    [email] VARCHAR(50) NOT NULL,
    [adresse] VARCHAR(100) NOT NULL,
    [phone] VARCHAR(10) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[produit] (
    [id]      INT           IDENTITY (1, 1) NOT NULL,
    [article] VARCHAR (50)  NOT NULL,
	[categorie] VARCHAR (50)  NOT NULL,
    [prix]    DECIMAL (18)  NOT NULL,
	[stock]    INT   NULL,
    [url]     VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
 
CREATE TABLE [dbo].[compte] (
    [id]            INT          IDENTITY (1, 1) NOT NULL,
    [solde]         DECIMAL (18) NOT NULL,
    [client_id]     INT          NOT NULL,

    PRIMARY KEY CLUSTERED ([id] ASC)
);


CREATE TABLE [dbo].[panier] (
    [id]             INT          IDENTITY (1, 1) NOT NULL,
    [compte_id]      INT          NOT NULL,
	[produit_id]      INT          NOT NULL,
    [date_panier] DATETIME     NOT NULL,
   	[montant]        DECIMAL (18) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);