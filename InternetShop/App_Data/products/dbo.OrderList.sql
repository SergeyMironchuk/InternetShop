CREATE TABLE [dbo].[OrderList]
(
	[Id]          INT         IDENTITY (1, 1) NOT NULL,
    [ProductId] INT NULL
	CONSTRAINT [PK_OrderList] PRIMARY KEY CLUSTERED ([Id] ASC),
	 [Kolich] INT NULL, 
    CONSTRAINT [FK_OrderList_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
)
