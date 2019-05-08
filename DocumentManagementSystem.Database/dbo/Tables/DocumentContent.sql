CREATE TABLE [dbo].[DocumentContent] (
    [Id]      UNIQUEIDENTIFIER           DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Content] VARBINARY (MAX) FILESTREAM NULL,
    UNIQUE NONCLUSTERED ([Id] ASC)
) FILESTREAM_ON [FileStreamGroup1];

