USE [RAM]
GO
/****** Object:  StoredProcedure [dbo].[watch]    Script Date: 10/4/2017 9:22:05 AM ******/
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
-- All of call
select TOP(3) 'qubu' as [qubu],getdate(),* FROM V_All_API_Call ORDER BY logdate desc;
-- All openned 
select top(3) 'dakai' as [dakai] ,getdate(),* from V_All_Clicked_Resources order by logdate desc;
-- topday top 500 call
SELECT        TOP (500)    apilogid as [JinTianTou500ID], logdate as [date], Cast(logtime as time(0)) as [Time],  cscontent, csendpoint, keywords, csip, cscountry, csregion, cscity, csuseragent
FROM            apilog where logdate >= @D 
ORDER BY apilogid DESC;




-- really call, not bot
declare @nb int
select @nb = count (apilogid) from apilog where logdate >= @D  AND csuseragent not like '%bot%' AND csuseragent not like '%bingpreview%';
SELECT        TOP (500) @nb as [bushijiqiren], apilogid as [ID], logdate as [date], Cast(logtime as time(0)) as [Time],  cscontent, csendpoint, keywords, csip, cscountry, csregion, cscity, csuseragent
FROM            apilog where logdate >= @D  AND csuseragent not like '%bot%' AND csuseragent not like '%bingpreview%'
ORDER BY apilogid DESC;




-- Top 10 city
select city  , NUm as [shulian] from [dbo].[V_All_User_From_City];




-- all called, from Canada city, from other country 
Select a0.logdate as[riqu] , a0.n [zongsu], ca.c [jiaguo], CONVERT(Decimal(8,2),100.0*ca.c/a0.n) as [jiaguobeifen] ,fo.f [qita], CONVERT(Decimal(8,2),100.0*fo.f/a0.n) as [qitabeifen] from 
( select a1.logdate, count(a1.apilogid) as [n] from apilog as a1 group by a1.logdate) as a0
left join 
(select a2.logdate,count(a2.apilogid) as [c] from apilog as a2 where a2.cscountry = 'CA' group  by a2.logdate  ) as CA
on a0.logdate= ca.logdate
left join
(select a3.logdate,count(a3.apilogid) as [f] from apilog as a3 where a3.cscountry != 'CA' AND a3.csuseragent not like '%bot%'  AND csuseragent not like '%bingpreview%'  group  by a3.logdate   ) as [fo]
on a0.logdate=fo.logdate
order by a0.logdate desc
END
