USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[CourierInsert]    Script Date: 9/8/2022 7:27:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CourierInsert]
	@Firstname as NVARCHAR(MAX)='',
	@Lastname as NVARCHAR(MAX)='',
	@CreatedDate as datetime=GETDATE
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Courier]
           ([Firstname]
           ,[LastName]
           ,[CreatedDate])
     VALUES
           (@Firstname
           ,@Lastname
           ,@CreatedDate)
END
GO


