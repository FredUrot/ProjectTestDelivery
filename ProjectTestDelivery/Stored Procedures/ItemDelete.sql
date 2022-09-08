USE [ProjectTestDelivery]
GO

/****** Object:  StoredProcedure [dbo].[ItemDelete]    Script Date: 9/8/2022 7:34:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ItemDelete]
	@ItemId as INT = 0
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [dbo].[Item]
      WHERE [ItemId] = @ItemId
END
GO


