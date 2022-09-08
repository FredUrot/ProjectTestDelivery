USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[ItemUpdate]    Script Date: 9/8/2022 7:45:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ItemUpdate]
	@ItemId as INT = 0,
	@ItemName as NVARCHAR(MAX)='',
	@ItemDescription as NVARCHAR(MAX)='',
	@Status as INT = 0,
	@CourierId as INT = 0,
	@CustomerId as INT = 0,
	@Proof as NVARCHAR(MAX)=''
AS
BEGIN

	UPDATE [dbo].[Item]
	   SET [CustomerId] = @CustomerId
		  ,[CourierId] = @CourierId
		  ,[ItemName] = @ItemName
		  ,[ItemDescription] = @ItemDescription
		  ,[Status] = @Status
		  ,[Proof] = CASE WHEN @Proof = '' then [Proof] else @Proof end
		WHERE ItemId = @ItemId
END
GO


