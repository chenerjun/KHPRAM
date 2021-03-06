USE [RAM]
GO
/****** Object:  StoredProcedure [crd].[Generate_EtlloadId_TaxonomyCode]    Script Date: 10/26/2017 6:45:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ===============================================================================
-- Author:		William Chen
-- Create date: 2017-10-24
-- Description:	For Kristen's Community Resource Database dashboard project
-- Gerenate all taxonomy Code and etlloadid 
-- ===============================================================================
ALTER PROCEDURE [crd].[Generate_EtlloadId_TaxonomyCode] 
 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	TRUNCATE TABLE CRD.ETLLoadID_TaxonomyCode;

	INSERT INTO CRD.ETLLoadID_TaxonomyCode (ETLLoadID, [TaxonomyCode],[EnteredOn],[UpdatedOn])
			select p.ETLLoadID, ltrim(rtrim(f.TaxonomyCode)) as TaxonomyCode ,p.EnteredOn , p.UpdatedOn 
			from etlload as p outer apply  [CRD].[F_taxonomyCode_FROM_ETLOAD](p.etlloadid) as f 
			order by p.etlloadid
END
