﻿CREATE TABLE [dbo].[DocumentContent] (
    [Id]      UNIQUEIDENTIFIER           DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Content] VARBINARY (MAX) FILESTREAM NULL,
    CONSTRAINT [PK_DocumentContent] PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Id] ASC)
) FILESTREAM_ON [FileStreamGroup1];

