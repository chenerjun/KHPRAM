USE [RAM]
GO
/****** Object:  View [dbo].[V_All_Category]    Script Date: 8/11/2017 2:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_All_Category]
AS
SELECT        t.TopCategory, COUNT(a.apilogid) AS Num
FROM            dbo.apilog AS a INNER JOIN
                         dbo.TopCategory AS t ON t.TopCategoryID = a.keywords
WHERE        (a.cscontent = 'TopCategory')
GROUP BY t.TopCategory
GO
