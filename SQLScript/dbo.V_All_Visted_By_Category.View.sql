USE [RAM]
GO
/****** Object:  View [dbo].[V_All_Visted_By_Category]    Script Date: 8/11/2017 2:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_All_Visted_By_Category] AS
select cc.Num + bb.num as num, bb.tid, bb.topcategory, bb.category  
from      [dbo].[V_All_Browse_By_Category]  as [bb] 
     join [dbo].[V_All_Category] as [cc] 
on cc.TopCategory = bb.TopCategory
GO
