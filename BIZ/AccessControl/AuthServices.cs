using System;
using DATA.EF;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIZ.AccessControl
{
    public  class AuthServices
    {
        private  RAMEntities db = new RAMEntities();

        public  List<string> GetAllowIps()
        {
            var response = db.Proc_Get_Allow_IP().ToList();

            return response;
        }

        public  List<string> GetAllowDomains()
        {
            var response = db.Proc_Get_Allow_Domain().ToList();

            return response;
        }
    }
}