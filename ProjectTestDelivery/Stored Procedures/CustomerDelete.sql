USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[CustomerDelete]    Script Date: 9/8/2022 7:30:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CustomerDelete]
	@CustomerId as Int =0
AS
BEGIN
	DELETE FROM [dbo].[Customer]
		WHERE [CustomerId] = @CustomerId
END
GO


