CREATE TABLE [dbo].[Users] (
    [IdUser]       INT            IDENTITY (1, 1) NOT NULL,
    [Login]        VARCHAR (50)   NOT NULL,
    [Name]         VARCHAR (100)  NULL,
    [PasswordHash] VARBINARY (64) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([IdUser] ASC)
);

