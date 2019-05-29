CREATE TABLE [dbo].[DocumentDocumentType] (
    [DocumentId]     INT NOT NULL,
    [DocumentTypeId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([DocumentId] ASC, [DocumentTypeId] ASC),
    FOREIGN KEY ([DocumentId]) REFERENCES [dbo].[Document] ([Id]),
    FOREIGN KEY ([DocumentTypeId]) REFERENCES [dbo].[DocumentType] ([Id])
);

