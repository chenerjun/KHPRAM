using DATA.EF;
using System;
using System.Linq;
using System.Net;
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
            string txtComputerName = "";

            try
            {
                //
                // 2017-11-21 add 
                //

                //string ecname = System.Environment.MachineName; //不好用，出来的结果是Host API Server 的名字，例如：RAMAPI
                //string[] computer_name = System.Net.Dns.GetHostEntry(request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });
                //txtComputerName = computer_name[0].ToString(); //应该还行，但是出了点问题， 家里的T530的request 没有Log
                //txtComputerName = Dns.GetHostName(); //不好用，出来的结果是Host API Server 的名字，例如：RAMAPI

                txtComputerName = request.UserHostName;  // 出来的还是IP, 只有这个可靠点


                db.Proc_apilog(dbschema, request.RequestType, 
                    format, para, lang, token, cscontent, csendpoint, keywords,
                    request.UserHostAddress,
                    response.StatusCode.ToString(),
                    Convert.ToInt32(response.StatusCode),
                    
                    txtComputerName,
                    //request.UserHostName,

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