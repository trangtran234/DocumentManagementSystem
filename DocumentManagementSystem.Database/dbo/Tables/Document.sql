CREATE TABLE [dbo].[Document] (
    [Id]                  INT              IDENTITY (1, 1) NOT NULL,
    [DocumentName]        VARCHAR (255)    NULL,
    [DocumentType]        VARCHAR (50)     NULL,
    [DocumentSize]        FLOAT (53)       NULL,
    [DocumentDescription] VARBINARY (MAX)  NULL,
    [ParentId]            INT              NULL,
    [Created]             DATETIME         NULL,
    [LastModified]        DATETIME         NULL,
    [DocumentContentId]   UNIQUEIDENTIFIER NOT NULL,
    [CreateBy]            INT              NOT NULL,
    [LastModifiedBy]      INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CreateBy]) REFERENCES [dbo].[Account] ([Id]),
    FOREIGN KEY ([DocumentContentId]) REFERENCES [dbo].[DocumentContent] ([Id]),
    FOREIGN KEY ([LastModifiedBy]) REFERENCES [dbo].[Account] ([Id]),
    UNIQUE NONCLUSTERED ([DocumentContentId] ASC)
);

