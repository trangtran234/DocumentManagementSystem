CREATE TABLE [dbo].[DocumentContent] (
    [Id]        UNIQUEIDENTIFIER           DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [ContendId] INT                        IDENTITY (1, 1) NOT NULL,
    [Content]   VARBINARY (MAX) FILESTREAM NULL,
    PRIMARY KEY CLUSTERED ([ContendId] ASC),
    UNIQUE NONCLUSTERED ([Id] ASC)
) FILESTREAM_ON [FileStreamGroup1];

