USE [RAM]
GO
/****** Object:  StoredProcedure [dbo].[watch]    Script Date: 3/2/2018 9:41:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[watch] 
@D date = NULL
 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
-- get today date 
	SET @D = CAST(ISNULL(@D, GETDATE()) as date);
-- 今日全部
select TOP(3) N'全部' as N'全部(含问卷和机器人)',getdate() as N'检查时刻',* FROM V_All_API_Call ORDER BY logdate desc;





-- 今日打开
select top(3) N'打开' as N'打开资源网页' ,getdate()  as N'检查时刻',* from V_All_Clicked_Resources order by logdate desc;


-- 今日分类
select 
	case 
		when cscontent='' then 'tester'
		when cscontent='unique' then 'Robot'
	end as [cscontent]
	, csendpoint 
	, count(apilogid) as ['数量'] 
	from ram.dbo.apilog  
	where logdate =CAST( GETDATE() as date)  and csuseragent like '%bot%'
	group by cscontent  ,csendpoint  
union
select 
	cscontent
	, csendpoint 
	, count(apilogid) as ['数量'] 
	from ram.dbo.apilog  
	where logdate =CAST( GETDATE() as date)   and cscontent != 'unique' and cscontent != ''
	group by cscontent  ,csendpoint  
union
select 
	cscontent
	, csendpoint 
	, count(apilogid) as ['数量'] 
	from ram.dbo.apilog  
	where logdate =CAST( GETDATE() as date)   and cscontent = 'unique'  and csuseragent not like '%bot%'
	group by cscontent  ,csendpoint  





-- 今日日志头500条
SELECT        TOP (500)    apilogid as N'今日头500日志', logdate as [date], Cast(logtime as time(0)) as [Time],  cscontent, csendpoint, keywords, csip, cscountry, csregion, cscity, csuseragent
FROM            apilog where logdate >= @D 
ORDER BY apilogid DESC;




-- really call, not bot
declare @nb int
select @nb = count (apilogid) from apilog where logdate >= @D  AND csuseragent not like '%bot%' AND csuseragent not like '%bingpreview%';
SELECT        TOP (500) @nb as N'人工含问卷头500条', apilogid as [ID], logdate as [date], Cast(logtime as time(0)) as [Time],  cscontent, csendpoint, keywords, csip, cscountry, csregion, cscity, csuseragent
FROM            apilog where logdate >= @D  AND csuseragent not like '%bot%' AND csuseragent not like '%bingpreview%'
ORDER BY apilogid DESC;




-- Top 10 city
select city as N'累计头10城(含加国问卷)' , NUm as N'数量' from [dbo].[V_All_User_From_City];


-- 本周头30个城市
SELECT city as N'本周前30城(含加国问卷)',  num as N'数量'  FROM [RAM].[dbo].[V_ThisWeek_User_From_Top30_City]


-- all called, from Canada city, from other country 
Select a0.logdate as N'日期(含问卷)' , a0.n N'总数', ca.c N'加拿大', CONVERT(Decimal(8,2),100.0*ca.c/a0.n) as N'加拿大百分' ,
fo.f N'其他国家', CONVERT(Decimal(8,2),100.0*fo.f/a0.n) as N'其他国家百分' , asu.s as N'全部问卷', jsu.s as N'加国问卷'
from 
( select a1.logdate, count(a1.apilogid) as [n] from apilog as a1 group by a1.logdate) as a0
left join 
(select a2.logdate,count(a2.apilogid) as [c] from apilog as a2 where a2.cscountry = 'CA' group  by a2.logdate  ) as CA
on a0.logdate= ca.logdate
left join
(select a3.logdate,count(a3.apilogid) as [f] from apilog as a3 where a3.cscountry != 'CA' AND a3.csuseragent not like '%bot%'  AND csuseragent not like '%bingpreview%'  group  by a3.logdate   ) as [fo]
on a0.logdate=fo.logdate
left join 
(select a4.logdate, count(a4.apilogid) as [s] from apilog as a4 where a4.cscontent = 'answer' group by a4.logdate)  as [asu]
on a0.logdate = asu.logdate
left join 
(select a5.logdate, count(a5.apilogid) as [s] from apilog as a5 where a5.cscontent = 'answer' and cscountry = 'CA' group by a5.logdate ) as jsu
on a0.logdate = jsu.logdate
order by a0.logdate desc
END

