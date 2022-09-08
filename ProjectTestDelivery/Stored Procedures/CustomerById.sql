USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[CustomerById]    Script Date: 9/8/2022 7:30:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CustomerById]
@CustomerId AS int=0
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [CustomerId]
      ,[Firstname]
      ,[Lastname]
      ,[Address]
      ,[CreatedDate]
  FROM [dbo].[Customer]
	WHERE [CustomerId] = @CustomerId
END
GO


