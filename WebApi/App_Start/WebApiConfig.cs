using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using BIZ.AccessControl;

namespace WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public static class WebApiConfig
    {
        static AuthServices authservices = new AuthServices();

        /// <summary>
        /// get all of allowable Domains 
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAuthDomains()
        {
            List<string> domains = authservices.GetAllowDomains();
            return domains;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Enables CORS for the specified domains for all WebApi Classes in our project
            //string allowdomain = Properties.Settings.Default.AllowDomain;


            string[] validdomains = GetAuthDomains().ToArray();
            string allowdomain = String.Join(",", validdomains);


            var cors = new EnableCorsAttribute(allowdomain, "*", "*");
            config.EnableCors(cors);


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CustomizeApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            // remove application/x-www-form-urlencoded
            // Failed to generate the sample for media type 'application/x-www-form-urlencoded'. Cannot use formatter 'JQueryMvcFormUrlEncodedFormatter' to write type 'email'.
            //config.Formatters.Clear();
            //config.Formatters.Add(new JsonMediaTypeFormatter());
            //config.Formatters.Add(new XmlMediaTypeFormatter()); 


        }
    }
}
