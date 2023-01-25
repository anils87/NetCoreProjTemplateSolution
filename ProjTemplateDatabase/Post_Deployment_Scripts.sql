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

-- START - Categories Table Entry
    IF((SELECT COUNT(1) FROM Categories)=0)
    BEGIN
        INSERT INTO Categories(Name,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate)
        VALUES ('Appliances',1,1,GETDATE(),1,GETDATE())
        ,('Books',1,1,GETDATE(),1,GETDATE())
    END
-- END - Categories Table Entry

-- START - Products Table Entry
    IF((SELECT COUNT(1) FROM Products)=0)
    BEGIN
        INSERT INTO Products(ProductName,CategoryId,Price,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate)
        VALUES ('Air Conditioner',1,45500,1,1,GETDATE(),1,GETDATE())
        ,('Cooler',1,7800,1,1,GETDATE(),1,GETDATE())
        ,('Vahana: Vehicles of the Gods',2,206,1,1,GETDATE(),1,GETDATE())
        ,('It Starts With Us',2,210,1,1,GETDATE(),1,GETDATE())
    END
-- END - Categories Table Entry