USE [RAM]
GO
/****** Object:  View [dbo].[V_Monthly_call]    Script Date: 8/11/2017 2:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[V_Monthly_call]
as
WITH MonthTable
AS (
    SELECT Month(Convert (date,'20170101'))  [Month]
    UNION ALL
     SELECT '2' 
    UNION ALL    
	SELECT '3'  
    UNION ALL
	SELECT '4' 
	    UNION ALL
     SELECT '5' 
    UNION ALL    
	SELECT '6'  
    UNION ALL
	SELECT '7' 
	    UNION ALL
     SELECT '8' 
    UNION ALL    
	SELECT '9'  
    UNION ALL
	SELECT '10' 
	    UNION ALL
     SELECT '11' 
    UNION ALL    
	SELECT '12'  
)
select  mt.Month , 
case 
when v.num is null then 0
else v.num
end as num
from MonthTable as mt
left join 
(select month(a.logdate) as m, count(apilogid) as num from apilog as a 
where year((getdate())) = Year(a.logdate)
group by month(a.logdate)) v on v.m = mt.Month


GO
