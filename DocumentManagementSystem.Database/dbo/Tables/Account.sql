CREATE TABLE [dbo].[Account] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Username] VARCHAR (255) NULL,
    [Password] VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

