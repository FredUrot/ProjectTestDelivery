USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[CourierDelete]    Script Date: 9/8/2022 7:25:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create PROCEDURE [dbo].[CourierDelete]
	@CourierId as int = 0
AS
BEGIN
	DELETE FROM [dbo].[Courier]
      WHERE [CourierId] = @CourierId
END
GO


