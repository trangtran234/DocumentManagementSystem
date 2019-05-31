CREATE TABLE [dbo].[DocumentHistory]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[DocumentId] INT NOT NULL,
	[ActionId] INT NOT NULL,
	[UserId] INT NOT NULL,
	[Date] DATETIME NOT NULL

	PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([DocumentId]) REFERENCES [dbo].[Document] ([Id]),
	FOREIGN KEY ([UserId]) REFERENCES [dbo].[Account] ([Id])
)
