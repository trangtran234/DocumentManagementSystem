CREATE TABLE [dbo].[DocumentTag] (
    [DocumentId] INT NOT NULL,
    [TagId]      INT NOT NULL,
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_DocumentTag] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([DocumentId]) REFERENCES [dbo].[Document] ([Id]),
    FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tag] ([Id])
);

