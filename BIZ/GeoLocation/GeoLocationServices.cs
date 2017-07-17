using DATA.EF;
using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace BIZ.GeoLocation
{
    public class GeoLocationServices
    {
        private RAMEntities db = new RAMEntities();

        public List<geolocation> GetIPCountry(string ip, string token)
        {
            long ipnum = 0;
            ipnum = (long)(uint)IPAddress.NetworkToHostOrder((int)IPAddress.Parse(ip).Address);
            var response = db.Proc_Get_Canadaip(ipnum,token).ToList()  ;
            return response;
        }
    }
}