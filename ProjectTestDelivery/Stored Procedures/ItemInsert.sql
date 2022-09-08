USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[ItemInsert]    Script Date: 9/8/2022 7:35:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ItemInsert]
	@Itemname as NVARCHAR(MAX)='',
	@ItemDescription as NVARCHAR(MAX)='',
	@CreatedDate as datetime=GETDATE,
	@Status as INT = 1,
	@CourierId as INT = 0,
	@CustomerId as INT = 0,
	@Proof as NVARCHAR(MAX)=''
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Item]
           ([CustomerId]
           ,[CourierId]
           ,[ItemName]
           ,[ItemDescription]
		   ,CreatedDate
           ,[Status]
		   ,[Proof])
     VALUES
           (@CustomerId
           ,@CourierId
           ,@Itemname
           ,@ItemDescription
		   ,@CreatedDate
           ,@Status
		   ,@Proof)
END
GO


