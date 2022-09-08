USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[ItemList]    Script Date: 9/8/2022 7:45:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ItemList]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [ItemId]
      ,[ItemName]
      ,[ItemDescription]
      ,[Status]
      ,i.[CreatedDate] as CreatedDate
      ,[Proof]
	  ,i.CourierId as CourierId
	  ,AC.Firstname as CourierFirstName  
	  ,AC.LastName as CourierLastName   
	  ,i.CustomerId as CustomerId
	  ,c.Firstname as CustomerFirstName  
	  ,c.Lastname as CustomerLastName  
	  ,c.Address as CustomerAddress
  FROM [dbo].[Item] AS I
  LEFT JOIN DBO.Courier AS AC ON I.CourierId = AC.CourierId
  LEFT JOIN DBO.Customer AS C ON I.CustomerId = C.CustomerId
END
GO


