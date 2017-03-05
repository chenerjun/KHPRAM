using DATA.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace BIZ.Locations
{
    public class LocationServices
    {
        private RAMEntities db = new RAMEntities();
        #region GoogleLocation
            public List<GoogleCityList> GetAllGoogleCitis()
            {
                var response = db.Proc_Get_Google_All_City().ToList();

                return response;

            }


            public List<GoogleCityList> GetGoogleCityByProvinceID(int pid)
            {
                var response = db.Proc_Get_Google_City_By_ProvinceID(pid).ToList();

                return response;
            }


            public List<GoogleCityList> GetGoogleCityByCid(int cid)
            {
                var response = db.Proc_Get_Google_City_By_GoogleCityID(cid).ToList();

                return response;
            }

            public List<GoogleCityList> GetIncrementGoogleCityList(string gc)
            {
                var response = db.Proc_Increment_Google_City(gc).ToList();

                return response;
            }
        #endregion googleLocation



    }
}