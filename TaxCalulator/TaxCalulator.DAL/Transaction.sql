CREATE TABLE [dbo].[TransactionData]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Account] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL, 
    [CurrencyCode] NCHAR(3) NOT NULL, 
    [Amount] INT NOT NULL
)
