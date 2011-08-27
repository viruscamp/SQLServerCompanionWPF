/****** Object:  View [dbo].[Order Details Extended]    Script Date: 08/20/2011 21:23:46 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[Order Details Extended]'))
DROP VIEW [dbo].[Order Details Extended]
GO


create view "Order Details Extended" AS
SELECT "Order Details".OrderID, "Order Details".ProductID, Products.ProductName, 
	"Order Details".UnitPrice, "Order Details".Quantity, "Order Details".Discount, 
	(CONVERT(money,("Order Details".UnitPrice*Quantity*(1-Discount)/100))*100) AS ExtendedPrice
FROM Products INNER JOIN "Order Details" ON Products.ProductID = "Order Details".ProductID
--ORDER BY "Order Details".OrderID

GO

