USE [RAM]
GO
/****** Object:  StoredProcedure [dbo].[Proc_Insert_Update_Table_TopCategoryID_SubCategoryID]    Script Date: 1/9/2018 4:03:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		William Chen
-- Create date: Nov.17, 2016
-- Description:	Modifying table [dbo].[TopCategoryID_SubCategoryID]
-- =============================================
ALTER PROCEDURE [dbo].[Proc_Insert_Update_Table_TopCategoryID_SubCategoryID]
	-- Add the parameters for the stored procedure here
@Tid int,
@SID INT,
@active bit = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
IF EXISTS ( SELECT [TopCategoryID_SubCategoryID] FROM [RAM].[dbo].[TopCategoryID_SubCategoryID]  
WHERE [TopCategoryID] = @Tid  AND [SubCategoryID] = @SID)
	BEGIN
		UPDATE [RAM].[dbo].[TopCategoryID_SubCategoryID] SET
			[Active] = @active,
			[ChangedDate] = GETDATE()
		WHERE [TopCategoryID] = @TID  AND [SubCategoryID] = @SID
	END
ELSE
	BEGIN
		INSERT INTO  [RAM].[dbo].[TopCategoryID_SubCategoryID]
		([TopCategoryID],[SubCategoryID],[Active],[ChangedDate])
		VALUES
		(@Tid,  @Sid ,  @active  , getdate())
	END

END
