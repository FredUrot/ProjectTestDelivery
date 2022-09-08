USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[ItemById]    Script Date: 9/8/2022 7:34:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ItemById]
	@ItemId as INT = 0
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [ItemId]
      ,[CustomerId]
      ,[CourierId]
      ,[ItemName]
      ,[ItemDescription]
      ,[Status]
      ,[CreatedDate]
      ,[Proof]
	FROM [dbo].[Item]
	WHERE ItemId = @ItemId
END
GO


