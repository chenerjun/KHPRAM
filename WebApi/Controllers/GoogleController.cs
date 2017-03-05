﻿using BIZ.Locations;
using DATA.EF;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Filters;

namespace WebApi.Controllers
{
    /// <summary>
    /// Get Google Location information, response JSON or XML format.
    /// </summary>
    [AuthorizeIPAddress]
    [FilterIP]
    public class GoogleController : ApiController
    {
        LocationServices locationservice = new LocationServices();


        #region get all Google cities list
            #region response JSON
            /// <summary>
            /// Get Google City location list, response format in JSON
            /// </summary>
            /// <returns>return google city list format in JSON</returns>
            [ActionName("json")]
            [Route("api/v2/google/city/json")]
            [ResponseType(typeof(GoogleCityList))]
            [HttpGet]
            public HttpResponseMessage GetAllGoogleCitis()
            {

                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var response = locationservice.GetAllGoogleCitis();

                return toJson(response);
            }
            #endregion response JSON


            #region response XML
            /// <summary>
            /// Get Google City location list, response format in XML
            /// </summary>
            /// <returns>Google city list format in xml</returns>
            [ActionName("xml")]
            [Route("api/v2/google/city/xml")]
            [ResponseType(typeof(GoogleCityList))]
            [HttpGet]
            public HttpResponseMessage GetAllGoogleCitis_XML()
            {

                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var xml = locationservice.GetAllGoogleCitis().ToList();
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
        #endregion response XML
        #endregion get all Google cities list



        #region Get GoogleCity By ProvinceID
            #region response JSON
        #region path
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pid">Provincial ID</param>
        /// <returns></returns>
        [ActionName("json")]
        [Route("api/v2/google/province/json/{pid}")]
        [ResponseType(typeof(GoogleCityList))]
        [HttpGet]
        public HttpResponseMessage GetGoogleCityByProvinceID(int pid)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var r = locationservice.GetGoogleCityByProvinceID(pid).ToList();
            return toJson(r);
        }
        #endregion path

        #region querystring
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pid">Provincial ID</param>
        /// <returns></returns>
        [ActionName("json")]
        [Route("api/v2/google/province/json")]
        [ResponseType(typeof(GoogleCityList))]
        [HttpGet]
        public HttpResponseMessage GetGoogleCityByProvinceID_QS(int pid)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var r = locationservice.GetGoogleCityByProvinceID(pid).ToList();
            return toJson(r);
        }
        #endregion querystring
        #endregion response JSON


            #region response XML
        #region path
        /// <summary>
        /// Get Google City location list by provincial ID, response format in XML
        /// </summary>
        /// <param name="pid">Provincial ID</param>
        /// <returns>return provincial city list format in XML</returns>
        [Route("api/v2/google/province/xml/{pid}")]
        [ResponseType(typeof(GoogleCityList))]
        [HttpGet]
        public HttpResponseMessage GetGoogleCityByProvince_XML(int pid)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var xml = locationservice.GetGoogleCityByProvinceID(pid).ToList();
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
        #endregion path

        #region Querystring
        /// <summary>
        /// Query string style, get Google City location list by provincial ID, response format in XML.
        /// </summary>
        /// <param name="pid">provincial ID</param>
        /// <returns>return provincial city list format in XML</returns>
        [Route("api/v2/google/province/xml")]
        [ResponseType(typeof(GoogleCityList))]
        [HttpGet]
        public HttpResponseMessage GetGoogleCityByProvince_XML_QS(int pid)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var xml = locationservice.GetGoogleCityByProvinceID(pid).ToList();
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
        #endregion Querystring
        #endregion resopnse XML
        #endregion Get GoogleCity By ProvinceID



        #region Get GoogleCity By GoogleCityid
        #region response JSON
        #region path
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cid">Google City ID</param>
        /// <returns></returns>
        [ActionName("json")]
        [Route("api/v2/google/location/json/{cid}")]
        [ResponseType(typeof(GoogleCityList))]
        [HttpGet]
        public HttpResponseMessage GetGoogleCityByCid(int cid)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var r = locationservice.GetGoogleCityByCid(cid);
            return toJson(r);
        }
        #endregion path

        #region querystring
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cid">Google City ID</param>
        /// <returns></returns>
        [ActionName("json")]
        [Route("api/v2/google/location/json")]
        [ResponseType(typeof(GoogleCityList))]
        [HttpGet]
        public HttpResponseMessage GetGoogleCityByCid_QS(int cid)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var r = locationservice.GetGoogleCityByCid(cid);
            return toJson(r);
        }
        #endregion querystring
        #endregion response JSON


        #region response XML
        #region path
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cid">Google City ID</param>
        /// <returns></returns>
        [Route("api/v2/google/location/xml/{cid}")]
        [ResponseType(typeof(GoogleCityList))]
        [HttpGet]
        public HttpResponseMessage GetGoogleCityByCid_XML(int cid)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var xml = locationservice.GetGoogleCityByCid(cid);
            if (xml != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, xml, "application/xml");
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }
        #endregion path

        #region querystring
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cid">Google City ID</param>
        /// <returns>Re</returns>
        [Route("api/v2/google/location/xml")]
        [ResponseType(typeof(GoogleCityList))]
        [HttpGet]
        public HttpResponseMessage GetGoogleCityByCid_XML_QS(int cid)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var xml = locationservice.GetGoogleCityByCid(cid);
            if (xml != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, xml, "application/xml");
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }
        #endregion querystring
        #endregion response XML
        #endregion GetG oogleCity By GoogleCityid




        #region Get Increment GoogleCity List
        #region response JSON
        #region path
        /// <summary>
        /// Increment get google location list, response format in JSON
        /// </summary>
        /// <param name="cl">Google City Name</param>
        /// <returns>return Google city location list in jsno list.</returns>
        [ActionName("json")]
        [Route("api/v2/google/suggestion/json/{cl}")]
        [ResponseType(typeof(GoogleCityList))]
        [HttpGet]
        public HttpResponseMessage GetIncrementGoogleCityList(string cl)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = locationservice.GetIncrementGoogleCityList(cl).ToList();
            return toJson(json);
        }
        #endregion path

        #region querystring
        /// <summary>
        /// Query string style, increment get google location list, response format in JSON
        /// </summary>
        /// <param name="cl"></param>
        /// <returns>return Google city location list in jsno list.</returns>
        [ActionName("json")]
        [Route("api/v2/google/suggestion/json")]
        [ResponseType(typeof(GoogleCityList))]
        [HttpGet]
        public HttpResponseMessage GetIncrementGoogleCityList_QS(string cl)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = locationservice.GetIncrementGoogleCityList(cl).ToList();
            return toJson(json);
        }
        #endregion querystring
        #endregion response JSON



        #region response xml
        #region path
        /// <summary>
        /// Increment get Google city location list, response format in xml
        /// </summary>
        /// <param name="cl">Google City Name</param>
        /// <returns>return Google city location list in xml list.</returns>
        [ActionName("xml")]
        [Route("api/v2/google/suggestion/xml/{cl}")]
        [ResponseType(typeof(GoogleCityList))]
        [HttpGet]
        public HttpResponseMessage GetIncrementGoogleCityList_XML(string cl)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var xml = locationservice.GetIncrementGoogleCityList(cl).ToList(); 
            if (xml != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, xml, "application/xml");
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }
        #endregion path

        #region querystring
        /// <summary>
        /// Query String style, increment get Google city location list, response format in xml
        /// </summary>
        /// <param name="cl">Google City Name</param>
        /// <returns>return Google city location list in xml list.</returns>
        [ActionName("xml")]
        [Route("api/v2/google/suggestion/xml")]
        [ResponseType(typeof(GoogleCityList))]
        [HttpGet]
        public HttpResponseMessage GetIncrementGoogleCityList_XML_QS(string cl)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var xml = locationservice.GetIncrementGoogleCityList(cl).ToList();
            if (xml != null)
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, xml, "application/xml");
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }
        #endregion querystring
        #endregion response xml
        #endregion Get Increment GoogleCity List




        private HttpResponseMessage toJson(Object r)
        {
            string thisJson = null;
            thisJson = JsonConvert.SerializeObject(r, Formatting.None);

            if (thisJson.Length < 5)
            {

                var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                // RAM code
                response.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                return response;
            }
            else
            {

                var response = this.Request.CreateResponse(HttpStatusCode.OK);

                response.Content = new StringContent(thisJson, Encoding.UTF8, "application/json");
                return response;
            }
        }
    }
}