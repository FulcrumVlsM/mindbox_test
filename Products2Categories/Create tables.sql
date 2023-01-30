CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1, 1) NOT NULL,
	[Name] NVARCHAR(255) NOT NULL,

	CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ID] ASC)
)
GO


CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1, 1) NOT NULL,
	[Name] NVARCHAR(255) NOT NULL,

	CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([ID] ASC)
)
GO


CREATE TABLE [dbo].[Products2Categories](
	[ProductID] INT NOT NULL,
	[CategoryID] INT NOT NULL,

	CONSTRAINT [PK_Products2Categories] PRIMARY KEY CLUSTERED ([ProductID], [CategoryID]),
	CONSTRAINT [FK_Products2Categories_Products] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ID]),
	CONSTRAINT [FK_Products2Categories_Categories] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([ID])
)
GO