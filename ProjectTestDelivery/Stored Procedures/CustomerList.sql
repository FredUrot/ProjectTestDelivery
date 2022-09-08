USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[CustomerList]    Script Date: 9/8/2022 7:32:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CustomerList]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [CustomerId]
      ,[Firstname]
      ,[Lastname]
      ,[Address]
      ,[CreatedDate]
  FROM [dbo].[Customer]
END
GO


