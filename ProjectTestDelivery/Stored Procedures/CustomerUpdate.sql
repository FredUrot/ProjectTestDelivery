USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[CustomerUpdate]    Script Date: 9/8/2022 7:33:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CustomerUpdate]
	@CustomerId as Int =0,
	@Firstname as NVARCHAR(MAX)='',
	@Lastname as NVARCHAR(MAX)='',
	@Address as NVARCHAR(MAX)=''
AS
BEGIN

	UPDATE [dbo].[Customer]
   SET [Firstname] = @Firstname
      ,[Lastname] = @Lastname
      ,[Address] = @Address
 WHERE [CustomerId] = @CustomerId
END
GO


