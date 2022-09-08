USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[CourierUpdate]    Script Date: 9/8/2022 7:29:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CourierUpdate]
	@CourierId as int = 0,
	@Firstname as NVARCHAR(MAX)='',
	@Lastname as NVARCHAR(MAX)=''
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Courier]
   SET [Firstname] = @Firstname
      ,[LastName] = @Lastname
 WHERE [CourierId] = @CourierId 
END
GO


