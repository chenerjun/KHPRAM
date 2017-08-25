USE [RAM]
GO

/****** Object:  View [dbo].[V_LastMonth_User_From_City]    Script Date: 8/13/2017 7:43:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE view [dbo].[V_All_User_From_City]
 AS
 SELECT   a.*  from
(select top (10) cscity + ', '+csregion+', '+ cscountry as [city] , count(apilogid) as [num]
from apilog 
where  cscountry ='CA' AND cscity != ''
group by cscity + ', '+csregion+', '+ cscountry 
order by num desc) as a 
GO




