USE [RAM]
GO
/****** Object:  StoredProcedure [crd].[Generate_TaxonomyCode]    Script Date: 10/24/2017 11:14:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Author:		<Author,,Name>
-- Create date: 2017-10-06
-- Description:	Gerenate all taxonomy Code from community resource database
-- Kristen, IR team request
-- ==========================================================================================
CREATE PROCEDURE [crd].[Generate_TaxonomyCode] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
TRUNCATE TABLE [crd].[DIMTaxonomyCode] ;
insert into   [crd].[DIMTaxonomyCode] ([DIMTaxonomyCode_Name])
 select distinct ltrim(rtrim(f.TaxonomyCode))  as TaxonomyCode  
 from ETLLoad as p outer apply  [dbo].[F_taxonomyCode](p.etlloadid) as f where f.TaxonomyCode is not null
END
