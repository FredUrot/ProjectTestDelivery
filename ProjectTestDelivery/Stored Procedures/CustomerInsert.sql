USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[CustomerInsert]    Script Date: 9/8/2022 7:31:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CustomerInsert]
	@Firstname as NVARCHAR(MAX)='',
	@Lastname as NVARCHAR(MAX)='',
	@Address as NVARCHAR(MAX)='',
	@CreatedDate as datetime=GETDATE
AS
BEGIN

	INSERT INTO [dbo].[Customer]
           ([Firstname]
           ,[Lastname]
           ,[Address]
           ,[CreatedDate])
     VALUES
           (@Firstname
           ,@Lastname
           ,@Address
           ,@CreatedDate)
END
GO


