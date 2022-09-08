USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[CourierList]    Script Date: 9/8/2022 7:28:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[CourierList]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [CourierId]
      ,[Firstname]
      ,[LastName]
      ,[CreatedDate]
  FROM [dbo].[Courier]
END
GO


