CREATE TABLE [dbo].[PotLuckDInners]
(
	[DinnerId] INT NOT NULL PRIMARY KEY, 
    [Time] TIME NULL, 
    [Date] DATE NULL, 
    [Venue] NVARCHAR(50) NULL, 
    [Host] NVARCHAR(50) NULL, 
    [AmountSpent] MONEY NULL
	CONSTRAINT [FKs_Host] FOREIGN KEY (Host) REFERENCES PotLuckMembers(FirstName)
)
