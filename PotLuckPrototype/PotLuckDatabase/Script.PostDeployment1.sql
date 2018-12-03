/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

BEGIN

DELETE FROM POTLUCKDINNERS;
DELETE FROM POTLUCKMEMBERS;

INSERT INTO POTLUCKMEMBERS (MEMBERID, FIRSTNAME, LASTNAME, AUTHORISED) VALUES
(1, 'Matthew', 'Martyn', 1),
(2, 'Kristian', 'Ybanez', 1),
(3, 'Chuan', 'Yeow', 0),
(4, 'Mitchell', 'Temov', 0)

INSERT INTO POTLUCKDINNERS (DINNERID, TIME, DATE, VENUE, HOSTID, HOST, AMOUNTSPENT, CANCELLED) VALUES
(1, '11:37:50', '2018-12-03',  'Grilled', 1, 'Matthew', $25, 0)

END;