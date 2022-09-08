USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[ItemAssignToCourier]    Script Date: 9/8/2022 7:33:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ItemAssignToCourier]
	@ItemId as INT = 0,
	@CourierId as INT = 0
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Item]
	   SET [CourierId] = @CourierId
		WHERE ItemId = @ItemId
END
GO


