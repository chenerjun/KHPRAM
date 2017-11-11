using DATA.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace BIZ.Log
{
    public class LogServices
    {

        private RAMEntities db = new RAMEntities();
        public void logservices(HttpRequest request, HttpResponseMessage response, string dbschema, string format,
             string para, string lang, string token, string cscontent, string csendpoint, string keywords)
        {
            //string csstatus = ;
            //int cscode = ;
            //string csip = ;
            //string cshost = ;
            //string csurl = ;
            //string csrequestType = ;
            //string csuseragent = ;
            try
            {
                db.Proc_apilog(dbschema, request.RequestType, 
                    format, para, lang, token, cscontent, csendpoint, keywords,
                    request.UserHostAddress,
                    response.StatusCode.ToString(),
                    Convert.ToInt32(response.StatusCode),
                    request.UserHostName,
                    request.Url.ToString(),
                    request.UserAgent);
            }
            catch ( Exception e)
            {
                e.Message.ToString();
            }
        }
    }
}