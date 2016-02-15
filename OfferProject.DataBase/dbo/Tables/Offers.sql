CREATE TABLE [dbo].[Offers] (
    [IdOffer]     INT           IDENTITY (1, 1) NOT NULL,
    [IdUser]      INT           NOT NULL,
    [NameOffer]   VARCHAR (100) NOT NULL,
    [Description] VARCHAR (150) NOT NULL,
    [Date]        DATE          NOT NULL,
    [Type]        SMALLINT      NOT NULL,
    [State]       VARCHAR (20)  NULL,
    CONSTRAINT [PK_Offers] PRIMARY KEY CLUSTERED ([IdOffer] ASC),
    CONSTRAINT [FK_IdUser] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[Users] ([IdUser])
);

