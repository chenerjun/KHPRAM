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


            try
            {
            //
            // 2017-11-21 add 
            //
            //string[] computer_name = System.Net.Dns.GetHostEntry(request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });
            //string ecname = System.Environment.MachineName;
            //string txtComputerName = "";
            //txtComputerName  = computer_name[0].ToString();
                //IPAddress ip = Dns.GetHostName.GetHostEntry("whybla01").AddressList.Where(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();
                //string _computerName = Dns.GetHostEntry(ip).HostName.ToString();
                string txtComputerName = Dns.GetHostName();
                



                db.Proc_apilog(dbschema, request.RequestType, 
                    format, para, lang, token, cscontent, csendpoint, keywords,
                    request.UserHostAddress,
                    response.StatusCode.ToString(),
                    Convert.ToInt32(response.StatusCode),
                    
                    txtComputerName,//request.UserHostName,

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