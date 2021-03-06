USE [RAM]
GO
/****** Object:  View [dbo].[V_All_Browse_By_Category]    Script Date: 8/11/2017 2:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_All_Browse_By_Category]
AS
SELECT        num, tid, t .TopCategory, 
                         CASE t .TopCategory WHEN 'Health' THEN 'Health' WHEN 'Indigenous Support Services' THEN 'Indigenous' WHEN 'Drugs, Alcohol and Gambling Support' THEN 'Drugs' WHEN 'Counselling and Mental Health Support'
                          THEN 'Counselling' WHEN 'Legal and Advocacy Support' THEN 'Legal' WHEN 'Housing and Homelessness Support' THEN 'Housing' WHEN 'Jobs Support' THEN 'Job' WHEN 'Violence and Abuse Support' THEN 'Violence'
                          WHEN 'LGBTQ Support Services' THEN 'LGBTQ' END AS category
FROM            Topcategory AS t JOIN
                             (SELECT        Count(api.apilogid) AS Num, kws.TID
                               FROM            apilog AS api CROSS apply
                                                             (SELECT        [dbo].[fn_get_TopcategoryID_from_Log_keywords](api.apilogid) AS [TID]) AS kws
                               WHERE        api.cscontent = 'unique'
                               GROUP BY kws.TID) AS a ON t .topcategoryId = a.TID
GO
