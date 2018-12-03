CREATE TABLE [dbo].[PotLuckMembers]
(
	[MemberId] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Authorised] BIT NULL
)
