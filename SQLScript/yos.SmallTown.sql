USE [RAM]
GO
-------------------------------
--
-- CANADA Smaller town 
--
-------------------------------
ALTER PROCEDURE [YOS].[SmallerTown]
@D DATE = '2017-09-01' 
AS
BEGIN
 
--SET @D = CAST(ISNULL(@D, GETDATE()) as date);
if object_id('tempdb..#SAMPLE') is not null
    drop table #SAMPLE;

CREATE TABLE #SAMPLE 
(
ID INT IDENTITY(1,1) NOT NULL,  
country nvarchar (2),
region nvarchar (2),
city nvarchar (20),
thip nvarchar (20),
host nvarchar (20) ,
lat numeric (18,10),
long numeric (18,10),
uagency nvarchar (500)  
)

DECLARE @UA NVARCHAR(500) 
------------------
-- Ontario
------------------
DECLARE  @M   NVARCHAR(20) = N'Thunder Bay'
DECLARE  @R NVARCHAR(2) =N'ON'
DECLARE  @C NVARCHAR(2) =N'CA'
DECLARE @lat numeric (18,10) = 48.40000000
DECLARE @long numeric (18,10) = -89.23330000
DECLARE  @Mip NVARCHAR(20) = '45.78.243.200'
SET @UA  =N'Mozilla/5.0 (iPad; CPU OS 9_3_5 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13G36 Safari/601.1'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Oakville'
SET  @R     = N'ON'
SET  @C     = N'CA'
SET  @lat   = 43.40320000
SET  @long  = -79.71860000
SET  @Mip   = N'173.243.33.10'
SET  @UA    =N'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_6) AppleWebKit/603.3.8 (KHTML, like Gecko) Version/10.1.2 Safari/603.3.8'

insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Brampton'
SET  @R     = N'ON'
SET  @C     = N'CA'
SET  @lat   = 43.71960000
SET  @long  = -79.68540000
SET  @Mip   = N'74.213.190.8'
SET @UA  =N'Mozilla/5.0 (Windows NT 6.3; WOW64; rv:55.0) Gecko/20100101 Firefox/55.0'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)






----------------------------
-- British Columbia
----------------------------
SET  @M     = N'Oliver'
SET  @R     = N'BC'
SET  @C     = N'CA'
SET  @lat   = 49.18330000
SET  @long  = -119.55000000
SET  @Mip   = N'24.207.119.250'
SET @UA  =N'Mozilla/5.0 (Windows NT 10.0; WOW64; rv:48.0) Gecko/20100101 Firefox/48.0'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Richmond'
SET  @R     = N'BC'
SET  @C     = N'CA'
SET  @lat   = 49.17000000
SET  @long  = -123.13680000
SET  @Mip   = N'209.53.144.254'
SET @UA  =N'Mozilla/5.0 (iPhone; CPU iPhone OS 10_3_3 like Mac OS X) AppleWebKit/603.3.8 (KHTML, like Gecko) Version/10.0 Mobile/14G60 Safari/602.1'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Kelowna'
SET  @R     = N'BC'
SET  @C     = N'CA'
SET  @lat   = 49.94970000
SET  @long  = -119.43390000
SET  @Mip   = N'24.71.126.252'
SET @UA  =N'Mozilla/5.0 (Linux; Android 5.0.1; 10DTB12A Build/LRX22C) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.125 Safari/537.36'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)



------------------
-- ALberta
------------------
SET  @M     = N'Rimbey'
SET  @R     = N'AB'
SET  @C     = N'CA'
SET  @lat   = 52.63330000
SET  @long  = -114.21670000
SET  @Mip   = N'162.212.68.88'
SET @UA  =N'Mozilla/5.0 (Windows NT 6.1; WOW64; rv:47.0) Gecko/20100101 Firefox/47.0'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Raymond'
SET  @R     = N'AB'
SET  @C     = N'CA'
SET  @lat   = 49.46670000
SET  @long  = -112.66670000
SET  @Mip   = N'173.0.196.188'
SET @UA  =N'Mozilla/5.0 (Linux; Android 5.1.1; SAMSUNG SM-G530W Build/LMY47X) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/3.3 Chrome/38.0.2125.102 Mobile Safari/537.36'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Lethbridge'
SET  @R     = N'AB'
SET  @C     = N'CA'
SET  @lat   = 49.65810000
SET  @long  = -112.74840000
SET  @Mip   = N'108.173.130.4'
SET @UA  =N'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_6) AppleWebKit/603.3.8 (KHTML, like Gecko) Version/10.1.2 Safari/603.3.8'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)


------------------
-- Saskatchewan
------------------
SET  @M     = N'Pascal'
SET  @R     = N'SK'
SET  @C     = N'CA'
SET  @lat   = 53.51670000
SET  @long  = -107.13330000
SET  @Mip   = N'192.95.139.52'
SET @UA  =N'Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Luseland'
SET  @R     = N'SK'
SET  @C     = N'CA'
SET  @lat   = 52.08330000
SET  @long  = -109.43330000
SET  @Mip   = N'64.110.250.192'
SET @UA  =N'Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Wymark'
SET  @R     = N'SK'
SET  @C     = N'CA'
SET  @lat   = 50.11670000
SET  @long  = -107.73330000
SET  @Mip   = N'198.254.188.32'
SET @UA  =N'Mozilla/5.0 (Macintosh; Intel Mac OS X 10_11_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)


------------------
-- Manitoba
------------------
SET  @M     = N'Roland'
SET  @R     = N'MB'
SET  @C     = N'CA'
SET  @lat   = 49.36670000
SET  @long  = -97.95000000
SET  @Mip   = N'172.97.61.240'
SET @UA  =N'Mozilla/5.0 (Linux; Android 5.0; SM-N900W8 Build/LRX21V) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.125 Mobile Safari/537.36'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Thompson'
SET  @R     = N'MB'
SET  @C     = N'CA'
SET  @lat   = 55.74350000
SET  @long  = -97.85580000
SET  @Mip   = N'205.200.37.224'
SET @UA  =N'Mozilla/5.0 (Linux; Android 5.1.1; SM-G530W Build/LMY47X) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/3.3 Chrome/38.0.2125.102 Mobile Safari/537.36'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Brandon'
SET  @R     = N'MB'
SET  @C     = N'CA'
SET  @lat   = 49.81740000
SET  @long  = -99.95650000
SET  @Mip   = N'162.221.252.12'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)


------------------
-- QUEBEC
------------------
SET  @M     = N'Crabtree'
SET  @R     = N'QC'
SET  @C     = N'CA'
SET  @lat   = 45.96710000
SET  @long  = -73.47160000
SET  @Mip   = N'173.177.171.152'
SET @UA  =N'Mozilla/5.0 (Linux; Android 7.0; SM-G955W Build/NRD90M; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/59.0.3071.125 Mobile Safari/537.36'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Québec'
SET  @R     = N'QC'
SET  @C     = N'CA'
SET  @lat   = 46.83040000
SET  @long  = -71.24550000
SET  @Mip   = N'104.163.167.224'
SET @UA  =N'Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Cantley'
SET  @R     = N'QC'
SET  @C     = N'CA'
SET  @lat   = 45.56680000
SET  @long  = -75.78270000
SET  @Mip   = N'50.100.4.6'
SET @UA  =N'Mozilla/5.0 (iPhone; CPU iPhone OS 10_2_1 like Mac OS X) AppleWebKit/602.4.6 (KHTML, like Gecko) Version/10.0 Mobile/14D27 Safari/602.1'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)

------------------
-- Nova Scotia
------------------
SET  @M     = N'Baddeck'
SET  @R     = N'NS'
SET  @C     = N'CA'
SET  @lat   = 46.10000000
SET  @long  = -60.75000000
SET  @Mip   = N'99.192.20.68'
SET @UA  =N'Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.90 Safari/537.36'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Brookfield'
SET  @R     = N'NS'
SET  @C     = N'CA'
SET  @lat   = 45.25000000
SET  @long  = -63.28330000
SET  @Mip   = N'184.171.195.120'
SET @UA  =N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 Edge/12.10240'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Tusket'
SET  @R     = N'NS'
SET  @C     = N'CA'
SET  @lat   = 43.85830000
SET  @long  = -65.97400000
SET  @Mip   = N'24.222.204.128'
SET @UA  =N'Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)



------------------
-- New Burnswick
------------------
SET  @M     = N'Saint John'
SET  @R     = N'NB'
SET  @C     = N'CA'
SET  @lat   = 45.23080000
SET  @long  = -66.09530000
SET  @Mip   = N'134.153.39.4'
SET @UA  =N'Mozilla/5.0 (Windows NT 10.0; WOW64; rv:48.0) Gecko/20100101 Firefox/48.0'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Fredericton'
SET  @R     = N'NB'
SET  @C     = N'CA'
SET  @lat   = 45.81190000
SET  @long  = -66.67630000
SET  @Mip   = N'99.232.126.128'
SET @UA  =N'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
SET  @M     = N'Moncton'
SET  @R     = N'NB'
SET  @C     = N'CA'
SET  @lat   = 46.09870000
SET  @long  = -64.80360000
SET  @Mip   = N'45.74.251.144'
SET @UA  =N'Mozilla/5.0 (iPhone; CPU iPhone OS 10_3_2 like Mac OS X) AppleWebKit/603.2.4 (KHTML, like Gecko) Version/10.0 Mobile/14F89 Safari/602.1'
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)
insert into #SAMPLE Values (@C,@R,@M,  @mIP, @Mip,@lat,	@long, @UA)

 

---- Create the variables for the random number generation
DECLARE @Random INT;
DECLARE @Upper INT;
DECLARE @Lower INT;

SET @Lower = 1 ---- The lowest random number
-- create random sample data
declare @sampleCount int 
select @sampleCount = Count(*) from #SAMPLE
select @Upper =  count (*) from #SAMPLE  
SELECT @Random = ROUND(((@Upper - @Lower -1) * RAND() + @Lower), 0)

 
declare @country nvarchar (2);
declare @region nvarchar (2);
declare @city nvarchar (20);
declare @thip nvarchar (20);
declare @host nvarchar (20) ;
declare @lat1 numeric (18,10);
declare @long1 numeric (18,10);
declare @uagency nvarchar (500) ;

select  @country  = country   from #sample   where id = @random 
select  @region   = region 	  from #sample   where id = @random
select  @city  	  = city  	  from #sample   where id = @random
select  @thip 	  = thip 	  from #sample   where id = @random
select  @host  	  = host  	  from #sample   where id = @random
select  @lat1  	  = lat  	  from #sample   where id = @random
select  @long1    = long  	  from #sample   where id = @random
select  @uagency  = uagency	  from #sample   where id = @random


-- work on APILOG table
select @Upper =  count (apilogid) from apilog where cscity = 'Mountain View' and logdate = @d
SELECT @Random = ROUND(((@Upper - @Lower -1) * RAND() + @Lower), 0)
 

 declare @myIP1 int
 

 
 select top (1) @myIP1 = apilogid from 
(select top (@Random ) apilogid from apilog  where  cscity = 'Mountain View' and logdate = @d   order by apilogid) a
order by apilogid desc
 

 select apilogid, logdate, logtime, cscontent, csendpoint,  csip, cscountry, csregion, cscity, latitude, longitude,  cshost,  csuseragent 
 from apilog 
 where apilogid = @myIP1 ;

 update apilog set 
  cscountry = @country ,
  csregion =  @region  ,
  cscity = @city  	 ,
  csip = @thip 	, 
  cshost = @host  ,	 
  latitude = @lat1  	, 
  longitude = @long1  ,	 
  csuseragent = @uagency 
 where apilogid = @myIP1;

SELECT        apilogid, logdate, logtime, cscontent, csendpoint,  csip, cscountry, csregion, cscity, latitude, longitude,  cshost,  csuseragent
FROM            apilog
WHERE        (apilogid = @myIP1)



 

END