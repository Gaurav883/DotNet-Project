


CREATE TABLE [dbo].[Product](
    [ProductID] [int] IDENTITY(1,1) NOT NULL,
    [ProductName] [varchar](200) NULL,
    [price] [int] NULL,
    [MRP] [int] NULL,
    [ManagerEmail] [varchar](20) NULL,
    [PhoneNumber] [varchar](12) NULL,
    [Description] [varchar](max) NULL,
    [Images] [varchar](max) NULL,
PRIMARY KEY CLUSTERED
(
    [ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


--------------


CREATE PROCEDURE [dbo].[sp_InsertProduct]
    @ProductName VARCHAR(200),
    @Price INT,
    @MRP INT,
    @ManagerEmail VARCHAR(20),
    @PhoneNumber VARCHAR(12),
    @Description VARCHAR(MAX),
    @Images VARCHAR(MAX)

AS

BEGIN
    INSERT INTO Product (ProductName, Price, MRP, ManagerEmail, PhoneNumber, Description, Images)
    VALUES (@ProductName, @Price, @MRP, @ManagerEmail, @PhoneNumber, @Description, @Images);
   

END;

-------------------
CREATE PROCEDURE [dbo].[sp_deleteProduct]
    @ProductID INT
AS
BEGIN
    DELETE FROM Product
    WHERE ProductID = @ProductID;
END


---------------------
CREATE PROCEDURE [dbo].[sp_updateProduct]
    @ProductID INT,
    @ProductName VARCHAR(200),
    @Price INT,
    @MRP INT,
    @ManagerEmail VARCHAR(20),
    @PhoneNumber VARCHAR(12),
    @Description VARCHAR(MAX),
    @Images VARCHAR(MAX)

AS

BEGIN
    UPDATE Product
    SET 
        ProductName = @ProductName,
        Price = @Price,
        MRP = @MRP,
        ManagerEmail = @ManagerEmail,
        PhoneNumber = @PhoneNumber,
        Description = @Description,
        Images = @Images
    WHERE ProductID = @ProductID;

END

-----------------------------
create proc sp_GetData
as
begin

select * from [dbo].[Product]

select Top 1 ProductID from [dbo].[Product] order by ProductID desc

end

exec sp_GetData
-------------------------------

select * from [dbo].[Product]
select count(productid) as 'count' from Product

create proc sp_GetProductCount
as
begin
select count(productid) as 'count' from Product

end


