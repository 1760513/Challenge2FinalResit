CREATE TABLE [dbo].[PotLuckDInners]
(
	[DinnerId] INT NOT NULL PRIMARY KEY, 
    [Time] TIME NULL, 
    [Date] DATE NULL, 
    [Venue] NVARCHAR(50) NULL, 
	[HostId] INT NULL,
    [Host] NVARCHAR(50) NULL, 
    [AmountSpent] MONEY NULL
	CONSTRAINT [FK_HostId] FOREIGN KEY (HostId) REFERENCES PotLuckMembers(MemberId),
	[Cancelled] BIT NULL, 
    CONSTRAINT [FK_Host] FOREIGN KEY (Host) REFERENCES PotLuckMembers(FirstName)
)
