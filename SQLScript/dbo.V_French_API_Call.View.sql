USE [RAM]
GO
/****** Object:  View [dbo].[V_French_API_Call]    Script Date: 8/11/2017 2:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_French_API_Call]
AS
SELECT        logdate, COUNT(logdate) AS French
FROM            dbo.apilog
WHERE        (lang = 'fr')
GROUP BY logdate
GO
 
