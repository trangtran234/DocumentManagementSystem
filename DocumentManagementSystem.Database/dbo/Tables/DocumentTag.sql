CREATE TABLE [dbo].[DocumentTag] (
    [DocumentId] INT NOT NULL,
    [TagId]      INT NOT NULL,
    [Id] INT IDENTITY (1, 1) NOT NULL, 
    FOREIGN KEY ([DocumentId]) REFERENCES [dbo].[Document] ([Id]),
    FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tag] ([Id]), 
    CONSTRAINT [PK_DocumentTag] PRIMARY KEY ([Id])
);

