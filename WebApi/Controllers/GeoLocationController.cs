using BIZ.GeoLocation;
using DATA.EF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Filters;

namespace WebApi.Controllers
{
    /// <summary>
    /// detect whether the request sends from Canada, response a JSON
    /// </summary>
    [AuthorizeIPAddress]
    [FilterIP]
    public class GeoLocationController : ApiController
    {
        GeoLocationServices geolocationservices = new GeoLocationServices();

        #region response JSON

        //Friendly
        /// <summary>
        /// Checking current request sends within Canada.
        /// </summary>
        /// <param name="ip">current request sends IP </param>
        /// <param name="token">Access token</param>
        /// <returns>return a json</returns>
        [ActionName("json")]
        [Route("api/v2/geo/json/{ip}/{token}")]
        [ResponseType(typeof(string))]
        [HttpGet]
        public HttpResponseMessage Geo(string ip, string token)
        {

            var country = geolocationservices.GetIPCountry(ip, token);
            
            return toJson(country);
        }
        //Query String
        /// <summary>
        /// Query String Style. Checking current request sends within Canada, response a JSON.
        /// </summary>
        /// <param name="ip">current request sends IP </param>
        /// <param name="token">Access token</param>
        /// <returns>return a json</returns>
        [ActionName("json")]
        [Route("api/v2/geo/json")]
        [ResponseType(typeof(string))]
        [HttpGet]
        public HttpResponseMessage Geo_QS(string ip, string token)
        {
            var country = geolocationservices.GetIPCountry(ip, token);
            return toJson(country);
        }
        #endregion




        #region Response XML
        //Friendly
        /// <summary>
        /// detect whether the request sends from Canada or not, return a XML list.
        /// </summary>
        /// <param name="ip">current request sends IP </param>
        /// <param name="token">Access token</param>
        /// <returns>return detect result format in XML</returns>
        [ActionName("value")]
        [Route("api/v2/geo/xml/{ip}/{token}")]
        [ResponseType(typeof(string))]
        [HttpGet]
        public HttpResponseMessage GeoX(string ip, string token)
        {
            return createXML(ip, token);
        }
        //Query String
        /// <summary>
        /// Query String style, detect whether the request sends from Canada or not, return a XML list.
        /// </summary>
        /// <param name="ip">current request sends IP </param>
        /// <param name="token">Access token</param>
        /// <returns>return detect result format in XML/returns>
        [ActionName("value")]
        [Route("api/v2/geo/xml")]
        [ResponseType(typeof(string))]
        [HttpGet]
        public HttpResponseMessage GeoX_QS(string ip, string token)
        {
            return createXML(ip, token);
        }

        private HttpResponseMessage createXML(string ip, string token)
        {

                var xml = geolocationservices.GetIPCountry(ip, token).ToList();
                if (xml.Count > 0)
                {
                    var response = Request.CreateResponse(HttpStatusCode.OK, xml, "application/xml");
                    return response;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }


        }
        #endregion Response XML




        private HttpResponseMessage toJson(Object r)
        {

                string thisJson = null;
                thisJson = JsonConvert.SerializeObject(r, Formatting.None);

                if (thisJson.Length < 3)
                {
                    var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                    response.Content = new StringContent(string.Empty, Encoding.UTF8, "text/html");
                    return response;
                }
                else
                {
                    var response = this.Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(thisJson, Encoding.UTF8, "text/html");
                    return response;
                }

        }
    }
}
