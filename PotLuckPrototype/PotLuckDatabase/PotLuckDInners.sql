CREATE TABLE [dbo].[PotLuckDInners]
(
	[DinnerId] INT NOT NULL PRIMARY KEY, 
    [Time] TIME NULL, 
    [Date] DATE NULL, 
    [Venue] NVARCHAR(50) NULL, 
	[HostId] INT NULL,
    [Host] NVARCHAR(50) NULL, 
    [AmountSpent] MONEY NULL,
	[Cancelled] BIT NULL, 
	CONSTRAINT [FK_HostId] FOREIGN KEY (HostId) REFERENCES PotLuckMembers(MemberId)
)
