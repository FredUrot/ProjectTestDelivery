USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[CourierById]    Script Date: 9/8/2022 7:23:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CourierById]
@CourierId AS int=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT [CourierId]
      ,[Firstname]
      ,[LastName]
      ,[CreatedDate]
  FROM [dbo].[Courier]
	WHERE [CourierId] =@CourierId
END
GO


