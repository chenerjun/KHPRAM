using BIZ.Search;
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
    /// Get Resource information by using resource’s ID, location, interest keyword(s), city, province, category etc.
    /// </summary>
    [AuthorizeIPAddress]
    [FilterIP]
    public class ResourceController : ApiController
    {
        private ResourceServices resourceservice = new ResourceServices();

        #region Get Resource by Lang
        #region JSON
        //Friendly
        /// <summary>
        /// Get all allowable resource list by language.
        /// </summary>
        /// <param name="lang">Language. English = "en"; French = "fr"</param>
        /// <param name="token">Access token</param>
        /// <returns>Return JSON format resource list, filter by language</returns>
        [ActionName("json")]
        [ResponseType(typeof(RamResource))]
        [Route("api/v2/resource/json/{token}/{lang}")]
        [Route("api/v2/Ressource/json/{token}/{lang}")]
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByLang(string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = resourceservice.GetAllResourcesByLang(lang, token).ToList();
            return toJson(json, lang);
        }
        //Query String
        /// <summary>
        /// Query string style getting allowable resource list by language.
        /// </summary>
        /// <param name="lang">Language. English = "en"; French = "fr"</param>
        /// <param name="token">Access token</param>
        /// <returns>Return JSON format resource list, filter by language</returns>
        [ActionName("json")]
        [Route("api/v2/resource/json")]
        [Route("api/v2/Ressource/json")]
        [ResponseType(typeof(RamResource))]
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByLang_QS(string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = resourceservice.GetAllResourcesByLang(lang, token).ToList();
            return toJson(json, lang);
        }
        #endregion JSON

        #region XML
        //Friendly
        /// <summary>
        /// Get all allowable resource list by language.
        /// </summary>
        /// <param name="lang">Language. English = "en"; French = "fr"</param>
        /// <param name="token">Access token</param>
        /// <returns>Return XML format resource list, filter by language</returns>
        [ActionName("xml")]
        [Route("api/v2/resource/xml/{token}/{lang}")]
        [Route("api/v2/Ressource/xml/{token}/{lang}")]
        [ResponseType(typeof(RamResource))]
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByLang_XML(string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            return createResourcehResult(lang, token);
        }
        //Query String
        /// <summary>
        /// Query String style getting all allowable resource list by language.
        /// </summary>
        /// <param name="lang">Language. English = "en"; French = "fr"</param>
        /// <param name="token">Access token</param>
        /// <returns>Return XML format resource list, filter by language</returns>
        [ActionName("xml")]
        [Route("api/v2/resource/xml")]
        [Route("api/v2/Ressource/xml")]
        [ResponseType(typeof(RamResource))]
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByLang_XML_QS(string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            return createResourcehResult(lang, token);
        }
        #endregion XML

        private HttpResponseMessage createResourcehResult(string lang, string token)
        {
            lang = lang.ToLower();
            if ((lang == "en") || (lang == "fr"))
            {
                var xml = resourceservice.GetAllResourcesByLang(lang, token).ToList();

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
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        #endregion Get Resource by Lang


        #region Get all Resource
            #region JSON
        /// <summary>
        /// Get allowable resource list return in JSON fromat
        /// </summary>
        /// <param name="token">Access token</param>
        /// <returns>Return resource list format in JSON</returns>
                [ActionName("Resource")]
                [Route("api/v2/resource/all/json/{token}")]
                [Route("api/v2/ressource/tout/json/{token}")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetAllResources(string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = resourceservice.GetAllResources(token).ToList();
                    return toJson(json, "en");
                }

                //Query String
                /// <summary>
                /// Query string style getting allowable resource list return in JSON format.
                /// </summary>
                /// <param name="token">Access token</param>
                /// <returns>Return JSON format resource list</returns>
                [ActionName("json")]
                [Route("api/v2/resource/all/json")]
                [Route("api/v2/Ressource/tout/json")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetAllResources_QS(string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = resourceservice.GetAllResources(token).ToList();
                    return toJson(json, "en");
                }

            #endregion JSON
            
            #region XML
                /// <summary>
                /// Get allowable resource list return in XML style.
                /// </summary>
                /// <param name="token">Access token</param>
                /// <returns>Return allowable resource list format in XML</returns>
                [ActionName("Resource")]
                [Route("api/v2/resource/all/xml/{token}")]
                [Route("api/v2/Ressource/tout/xml/{token}")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetAllResources_xml(string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var xml = resourceservice.GetAllResources(token).ToList();
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

                //Query String
                /// <summary>
                /// Query String style getting all allowable resource list.
                /// </summary>
                /// <param name="token">Access token</param>
                /// <returns>Return XML format allowable resource list</returns>
                [ActionName("xml")]
                [Route("api/v2/resource/all/xml")]
                [Route("api/v2/Ressource/tout/xml")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetAllResources_XML_QS( string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var xml = resourceservice.GetAllResources(token).ToList();
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

        #endregion XML
        #endregion Get All Resource


        #region Get Resource By Type
        #region JSON
        #region Path
        /// <summary>
        /// Path resource type to get allowable resource list filter by language.
        /// </summary>
        /// <param name="type">Resource type Map:"M"; List:"L"; Both:"B"; Shelter:"S";</param>
        /// <param name="token">Access token</param>
        /// <param name="lang">language. English = "en"; French = "fr"</param>
        /// <returns>Return allowable resource list format in json</returns>
        [ActionName("Resource")]
        [Route("api/v2/resource/type/json/{token}/{lang}/{type}")]
        [Route("api/v2/ressource/type/json/{token}/{lang}/{type}")]
        [ResponseType(typeof(RamResource))]
        [HttpGet]
        public HttpResponseMessage GetResourcesByType(string type, string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = resourceservice.GetResourceByType(type,lang,token).ToList();
            return toJson(json, lang);
        }
        #endregion Path

        #region queryString
        /// <summary>
        /// Query resource type to get allowable resource list filter by language.
        /// </summary>
        /// <param name="type">Resource type Map:"M"; List:"L"; Both:"B"; Shelter:"S";</param>
        /// <param name="lang">Language. English = "en"; French = "fr"</param>
        /// <param name="token">Access token</param>
        /// <returns>Return allowable resource list format in json</returns>
        [ActionName("Resource")]
        [Route("api/v2/resource/type/json")]
        [Route("api/v2/ressource/type/json")]
        [ResponseType(typeof(RamResource))]
        [HttpGet]
        public HttpResponseMessage GetResourcesByType_QS(string type, string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = resourceservice.GetResourceByType(type, lang, token).ToList();
            return toJson(json, lang);
        }
        #endregion queryString
        #endregion JSON

        #region XML
        #region Path
        /// <summary>
        /// Path resource type to get allowable resource xml list filter by language.
        /// </summary>
        /// <param name="type">Resource type Map:"M"; List:"L"; Both:"B"; Shelter:"S";</param>
        /// <param name="lang">Language. English = "en"; French = "fr"</param>
        /// <param name="token">Access token</param>
        /// <returns>Return allowable resource list format in XML</returns>
        [ActionName("Resource")]
        [Route("api/v2/resource/type/xml/{token}/{lang}/{type}")]
        [Route("api/v2/ressource/type/xml/{token}/{lang}/{type}")]
        [ResponseType(typeof(RamResource))]
        [HttpGet]
        public HttpResponseMessage GetResourcesByType_XML(string type, string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = resourceservice.GetResourceByType(type, lang, token).ToList();
            return createResourcehTypeResult(type, lang, token);
        }
        #endregion Path

        #region queryString
        /// <summary>
        /// Query resource type to get allowable resource xml list filter by language.
        /// </summary>
        /// <param name="type">Resource type Map:"M"; List:"L"; Both:"B"; Shelter:"S";</param>
        /// <param name="lang">Language. English = "en"; French = "fr"</param>
        /// <param name="token">Access token</param>
        /// <returns>Return allowable resource list format in XML</returns>
        [ActionName("Resource")]
        [Route("api/v2/resource/type/xml")]
        [Route("api/v2/ressource/type/xml")]
        [ResponseType(typeof(RamResource))]
        [HttpGet]
        public HttpResponseMessage GetResourcesByType_XML_QS(string type, string lang, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = resourceservice.GetResourceByType(type, lang, token).ToList();
            return createResourcehTypeResult(type, lang, token);
        }
        #endregion queryString
        private HttpResponseMessage createResourcehTypeResult(string type, string lang, string token)
        {
            lang = lang.ToLower();
            if ((lang == "en") || (lang == "fr"))
            {
                var xml = resourceservice.GetResourceByType(type, lang, token).ToList();

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
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        #endregion XML
        #endregion Get Resource By Type


        #region Get Resource By ID
        #region JSON
        //Friendly
        /// <summary>
        ///  Get specific allowable resource by its id, filter by resource's language 
        /// </summary>
        /// <param name="lang">language. English = "en"; French = "fr"</param>
        /// <param name="rid">resource id</param>
        /// <param name="token">Access token</param>
        /// <returns>return a JSON format specific resource's detail information</returns>
        [ActionName("json")]
                [Route("api/v2/resource/json/{token}/{lang}/{rid}")]
                [Route("api/v2/Ressource/json/{token}/{lang}/{rid}")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetResourcesByID(string lang, int rid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = resourceservice.GetResourcesByID(lang,rid,token);
                    return toJson(json, lang);
                }
                //Query String
                /// <summary>
                ///  Query String style getting allowable specific resource by its id, filter by resource's language 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="rid">resource id</param>
                /// <param name="token">Access token</param>
                /// <returns>return a JSON format specific resource's detail information</returns>
                [ActionName("json")]
                [Route("api/v2/resource/json")]
                [Route("api/v2/Ressource/json")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetResourcesByID_QS(string lang, int rid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = resourceservice.GetResourcesByID(lang, rid, token);
                    return toJson(json, lang);
                }
            #endregion JSON

            #region XML
                /// <summary>
                ///  Get allowable specific resource by its id, filter by resource's language 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="rid">resource id</param>
                /// <param name="token">Access token</param>
                /// <returns>return a XML format specific resource's detail information</returns>
                //Friendly
                [ActionName("xml")]
                [Route("api/v2/resource/xml/{token}/{lang}/{rid}")]
                [Route("api/v2/Ressource/xml/{token}/{lang}/{rid}")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GGetResourcesByID_XML(string lang, int rid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    return CreateResourcesByID(lang, rid, token);
                }
                //Query String
                /// <summary>
                ///  Query String style getting allowable specific resource by its id, filter by resource's language 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="rid">resource id</param>
                /// <param name="token">Access token</param>
                /// <returns>return a XML format specific resource's detail information</returns>
                [ActionName("xml")]
                [Route("api/v2/resource/xml")]
                [Route("api/v2/Ressource/xml")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetResourcesByID_XML_QS(string lang, int rid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    return CreateResourcesByID(lang, rid, token);
                }
                private HttpResponseMessage CreateResourcesByID(string lang, int rid, string token)
                {
                    lang = lang.ToLower();
                    if ((lang == "en") || (lang == "fr"))
                    {
                        var xml = resourceservice.GetResourcesByID(lang, rid, token);
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
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                }
            #endregion XML
        #endregion Get Resource By ID


        #region Get Unique Resource By 
                #region JSON
                //Friendly
                /// <summary>
                ///  For email favour list to user, it will track user selected resource for a period of time. get specific resource by language, map, resource agency number, SubCategory id, top category id 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="map">map resource. such as mapped, list, both, shelter</param>
                /// <param name="ran">resourceAgencyNum id</param>
                /// <param name="sid">SubCategoryid id</param>
                /// <param name="tid">top category id</param>
                /// <param name="token">Access token</param>
                /// <returns>return a JSON format specific resource's detail information</returns>
                /// 
                [ActionName("json")]
                [Route("api/v2/resource/favour/json/{token}/{lang}/{map}/{ran}/{sid}/{tid}")]
                [Route("api/v2/Ressource/favoriser/json/{token}/{lang}/{map}/{ran}/{sid}/{tid}")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetUniqueResources(string lang, string map, string ran, int sid, int tid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = resourceservice.GetUniqueResources(map, ran, sid, tid, lang, token);
                    return toJson(json, lang);
                }
                //Query String
                /// <summary>
                ///  For email favour list to user, it will track user selected resource for a period of time. Query String style getting specific resource by by language, map, resource agency number, SubCategory id, top category id 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="map">map resource. such as mapped, list, both, shelter</param>
                /// <param name="ran">resourceAgencyNum id</param>
                /// <param name="sid">SubCategoryid id</param>
                /// <param name="tid">top category  id</param>
                /// <param name="token">Access token</param>
                /// <returns>return a JSON format specific resource's detail information</returns>
                [ActionName("json")]
                [Route("api/v2/resource/favour/json")]
                [Route("api/v2/Ressource/favoriser/json")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetUniqueResources_QS(string lang, string map, string ran, int sid, int tid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = resourceservice.GetUniqueResources(map, ran, sid, tid, lang, token); 
                    return toJson(json, lang);
                }
                #endregion JSON

                #region XML
                /// <summary>
                ///  For email favour list to user, it will track user selected resource for a period of time. XML format, get specific resource by language, map, resource agency number, SubCategory id, top category id 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="map">map resource. such as mapped, list, both, shelter</param>
                /// <param name="ran">resourceAgencyNum id</param>
                /// <param name="sid">SubCategoryid id</param>
                /// <param name="tid">top category  id</param>
                /// <param name="token">Access token</param>
                /// <returns>return a XML format specific resource's detail information</returns>
                //Friendly
                [ActionName("xml")]
                [Route("api/v2/resource/favour/xml/{token}/{lang}/{map}/{ran}/{sid}/{tid}")]
                [Route("api/v2/Ressource/favoriser/xml/{token}/{lang}/{map}/{ran}/{sid}/{tid}")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetUniqueResources_XML(string lang, string map, string ran, int sid, int tid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    return CreateUniqueResources(lang, map, ran, sid, tid, token);
                }
                //Query String
                /// <summary>
                ///  For email favour list to user, it will track user selected resource for a period of time. Query String style getting specific resource by language, map, resource agency number, SubCategory id, top category id 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="map">map resource. such as mapped, list, both, shelter</param>
                /// <param name="ran">resourceAgencyNum id</param>
                /// <param name="sid">SubCategory id</param>
                /// <param name="tid">top category  id</param>
                /// <param name="token">Access token</param>
                /// <returns>return a XML format specific resource's detail information</returns>
                [ActionName("xml")]
                [Route("api/v2/resource/favour/xml")]
                [Route("api/v2/Ressource/favoriser/xml")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetUniqueResources_XML_QS(string lang, string map, string ran, int sid, int tid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    return CreateUniqueResources(lang, map, ran, sid, tid, token);
                }
                private HttpResponseMessage CreateUniqueResources(string lang, string map, string ran, int sid, int tid, string token)
                {
                    lang = lang.ToLower();
                    if ((lang == "en") || (lang == "fr"))
                    {
                        var xml = resourceservice.GetUniqueResources(map, ran, sid, tid, lang, token);
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
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                }
                #endregion XML
        #endregion Get Unique Resource By


        #region Get Resource By City ID
            #region JSON
                // Friendly
                /// <summary>
                ///  Get resource list in the specific allowable city filter by resource's language 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="cid">city id</param>
                /// <param name="token">Access token</param>
                /// <returns>return a JSON format resource list located in a specific city</returns>
                [ActionName("json")]
                [Route("api/v2/resource/city/json/{token}/{lang}/{cid}")]
                [Route("api/v2/Ressource/ville/json/{token}/{lang}/{cid}")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetAllResourcesByCity(string lang, int cid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = resourceservice.GetResourcesByCity(cid, lang, token).ToList();
                    return toJson(json, lang);
                }
                // Query String
                /// <summary>
                ///  Query String style getting resource list in the specific allowable city filter by resource's language 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="cid">city id</param>
                /// <param name="token">Access token</param>
                /// <returns>return a JSON format resource list located in a specific city</returns>
                [ActionName("json")]
                [Route("api/v2/resource/city/json")]
                [Route("api/v2/Ressource/ville/json")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetAllResourcesByCity_QS(string lang, int cid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = resourceservice.GetResourcesByCity(cid, lang, token).ToList();
                    return toJson(json, lang);
                }
            #endregion JSON

            #region XML
                // Friendly
                /// <summary>
                ///  Get resource list in the specific allowable city filter by resource's language 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="cid">city id</param>
                /// <param name="token">Access token</param>
                /// <returns>return a XML format resource list located in a specific city</returns>
                [ActionName("xml")]
                [Route("api/v2/resource/city/xml/{token}/{lang}/{cid}")]
                [Route("api/v2/Ressource/ville/xml/{token}/{lang}/{cid}")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetAllResourcesByCity_XML(string lang, int cid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    return createResourcesByCityResult(cid, lang, token);
                }
                // Query String
                /// <summary>
                ///  Query String style getting resource list in the specific allosing city filter by resource's language 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="cid">city id</param>
                /// <param name="token">Access token</param>
                /// <returns>return a XML format resource list located in a specific city</returns>
                [ActionName("xml")]
                [Route("api/v2/resource/city/xml")]
                [Route("api/v2/Ressource/ville/xml")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetAllResourcesByCity_XML_QS(string lang, int cid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    return createResourcesByCityResult(cid, lang, token);
                }
                private HttpResponseMessage createResourcesByCityResult(int cid, string lang, string token)
                {
                    lang = lang.ToLower();
                    if ((lang == "en") || (lang == "fr"))
                    {
                        var xml = resourceservice.GetResourcesByCity(cid, lang, token).ToList();

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
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                }
            #endregion XML
        #endregion Get Resource By City ID


        #region Get Resource By Province ID
            #region JSON
                // Friendly
                /// <summary>
                ///  Get resource list in the specific allowable province filter by resource's language 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="pid">province id</param>
                /// <param name="token">Access token</param>
                /// <returns>return a JSON format resource list located in a specific province</returns>
                [ActionName("json")]
                [Route("api/v2/resource/province/json/{token}/{lang}/{pid}")]
                [Route("api/v2/Ressource/province/json/{token}/{lang}/{pid}")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetAllResourcesByProvince(string lang, int pid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = resourceservice.GetResourcesByProvince(pid, lang, token).ToList();
                    return toJson(json, lang);
                }
                // Query String
                /// <summary>
                ///  Query String style getting resource list in the specific allowable province filter by resource's language 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="pid">province id</param>
                /// <param name="token">Access token</param>
                /// <returns>return a XML format resource list located in a specific province</returns>
                [ActionName("json")]
                [Route("api/v2/resource/province/json")]
                [Route("api/v2/Ressource/province/json")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetAllResourcesByProvince_QS(string lang, int pid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = resourceservice.GetResourcesByProvince(pid, lang, token).ToList();
                    return toJson(json, lang);
                }
        #endregion JSON

            #region XML
                // Friendly
                /// <summary>
                ///  Get resource list in the specific allowable province filter by resource's language 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="pid">province id</param>
                /// <param name="token">Access token</param>
                /// <returns>return a XML format resource list located in a specific province</returns>
                [ActionName("xml")]
                [Route("api/v2/resource/province/xml/{token}/{lang}/{pid}")]
                [Route("api/v2/Ressource/province/xml/{token}/{lang}/{pid}")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetAllResourcesByProvince_XML(string lang, int pid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    return createResourcesByProvinceResult(pid, lang, token);
                }
                // Query String
                /// <summary>
                ///  Query String style getting resource list in the specific allowable province filter by resource's language 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="pid">province id</param>
                /// <param name="token">Access token</param>
                /// <returns>return a XML format resource list located in a specific province</returns>
                [ActionName("xml")]
                [Route("api/v2/resource/province/xml")]
                [Route("api/v2/Ressource/province/xml")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetAllResourcesByProvince_XML_QS(string lang, int pid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    return createResourcesByProvinceResult(pid, lang, token);
                }
                private HttpResponseMessage createResourcesByProvinceResult(int pid, string lang, string token)
                {
                    lang = lang.ToLower();
                    if ((lang == "en") || (lang == "fr"))
                    {
                        var xml = resourceservice.GetResourcesByProvince(pid, lang, token).ToList();

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
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                }
            #endregion XML
        #endregion Get Resource By Province ID


        #region Get Resource By SubCategory ID
            #region JSON
                // Friendly
                /// <summary>
                ///  Get resource list under the SubCategory filter by resource's language 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="sid">SubCategory id.</param>
                /// <param name="token">Access token</param>
                /// <returns>Return a JSON format resource list under the specific SubCategory</returns>
                [ActionName("json")]
                [Route("api/v2/Resource/SubCategory/json/{token}/{lang}/{sid}")]
                [Route("api/v2/Ressource/souscatégorie/json/{token}/{lang}/{sid}")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetAllResourcesBySubCategory(string lang, int sid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = resourceservice.GetResourcesBySubCategory(sid, lang, token).ToList();
                    return toJson(json, lang);
                }
                // Query String
                /// <summary>
                ///  Query String style, Get resource list under the SubCategory filter by resource's language 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="sid">SubCategory id.</param>
                /// <param name="token">Access token</param>
                /// <returns>Return a JSON format resource list under the specific SubCategory</returns>
                [ActionName("json")]
                [Route("api/v2/resource/SubCategory/json")]
                [Route("api/v2/Ressource/souscatégorie/json")]
                [ResponseType(typeof(RamResource))]
                [HttpGet]
                public HttpResponseMessage GetAllResourcesBySubCategory_QS(string lang, int sid, string token)
                {
                    HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                    var json = resourceservice.GetResourcesBySubCategory(sid, lang, token).ToList();
                    return toJson(json, lang);
                }
            #endregion JSON

            #region XML
            // Friendly
                /// <summary>
                ///  Get resource list under the SubCategory filter by resource's language 
                /// </summary>
                /// <param name="lang">language. English = "en"; French = "fr"</param>
                /// <param name="sid">SubCategory id.</param>
                /// <param name="token">Access token</param>
                /// <returns>Return a XML format resource list under the specific SubCategory</returns>
            [ActionName("xml")]
            [Route("api/v2/resource/SubCategory/xml/{token}/{lang}/{sid}")]
            [Route("api/v2/Ressource/souscatégorie/xml/{token}/{lang}/{sid}")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
                public HttpResponseMessage GetAllResourcesBySubCategory_XML(string lang, int sid, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                return createResourcesBySubCategoryResult(sid, lang, token);
            }
            // Query String
            /// <summary>
            ///  Query String Style. Get resource list under the SubCategory filter by resource's language 
            /// </summary>
            /// <param name="lang">language. English = "en"; French = "fr"</param>
            /// <param name="sid">SubCategory id.</param>
            /// <param name="token">Access token</param>
            /// <returns>Return a XML format resource list under the specific SubCategory</returns>
            [ActionName("xml")]
            [Route("api/v2/resource/SubCategory/xml")]
            [Route("api/v2/Ressource/souscatégorie/xml")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage GetAllResourcesBySubCategory_XML_QS(string lang, int sid, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                return createResourcesBySubCategoryResult(sid, lang, token);
            }
            private HttpResponseMessage createResourcesBySubCategoryResult(int sid, string lang, string token)
            {
                lang = lang.ToLower();
                if ((lang == "en") || (lang == "fr"))
                {
                    var xml = resourceservice.GetResourcesBySubCategory(sid, lang, token).ToList();

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
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
        #endregion XML
        #endregion Get Resource By SubCategory ID


        #region Get Resource By TopCategory ID
            #region JSON
            // Friendly
            /// <summary>
            ///  Get resource list under allowable TopCategory, filter by resource's language 
            /// </summary>
            /// <param name="lang">language. English = "en"; French = "fr"</param>
            /// <param name="tid">TopCategory id.</param>
            /// <param name="token">Access token</param>
            /// <returns>Return a JSON format resource list under the specific TopCategory</returns>
            [ActionName("json")]
            [Route("api/v2/resource/topcategory/json/{token}/{lang}/{tid}")]
            [Route("api/v2/Ressource/catégorie/json/{token}/{lang}/{tid}")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage GetAllResourcesByTopCategory(string lang, int tid, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = resourceservice.GetResourcesByTopCategory(tid, lang, token).ToList();
                return toJson(json, lang);
            }

            // Query String
            /// <summary>
            ///  Query String Style. Get resource list under allowable TopCategory filter by resource's language 
            /// </summary>
            /// <param name="lang">language. English = "en"; French = "fr"</param>
            /// <param name="tid">TopCategory id.</param>
            /// <param name="token">Access token</param>
            /// <returns>Return a JSON format resource list under the specific TopCategory</returns>
            [ActionName("json")]
            [Route("api/v2/resource/topcategory/json")]
            [Route("api/v2/Ressource/catégorie/json")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage GetAllResourcesByTopCategory_QS(string lang, int tid, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = resourceservice.GetResourcesByTopCategory(tid, lang, token).ToList();
                return toJson(json, lang);
            }
            #endregion JSON

            #region XML
            // Friendly
            /// <summary>
            ///  Get resource list under allowable TopCategory filter by resource's language 
            /// </summary>
            /// <param name="lang">language. English = "en"; French = "fr"</param>
            /// <param name="tid">TopCategory id.</param>
            /// <param name="token">Access token</param>
            /// <returns>Return a XML format resource list under the specific TopCategory</returns>
            [ActionName("xml")]
            [Route("api/v2/resource/topcategory/xml/{token}/{lang}/{tid}")]
            [Route("api/v2/Ressource/catégorie/xml/{token}/{lang}/{tid}")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage GetAllResourcesByTopCategory_XML(string lang, int tid, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                return createResourcesByTopcategoryResult(tid, lang, token);
            }


            // Query String
            /// <summary>
            ///  Query String Style. Get resource list under allowable TopCategory filter by resource's language 
            /// </summary>
            /// <param name="lang">language. English = "en"; French = "fr"</param>
            /// <param name="tid">TopCategory id.</param>
            /// <param name="token">Access token</param>
            /// <returns>Return a XML format resource list under the specific TopCategory</returns>
            [ActionName("xml")]
            [Route("api/v2/resource/topcategory/xml")]
            [Route("api/v2/Ressource/catégorie/xml")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage GetAllResourcesByTopCategory_XML_QS(string lang, int tid, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                return createResourcesByTopcategoryResult(tid, lang, token);
            }
            private HttpResponseMessage createResourcesByTopcategoryResult(int tid, string lang, string token)
            {
                lang = lang.ToLower();
                if ((lang == "en") || (lang == "fr"))
                {
                    var xml = resourceservice.GetResourcesByTopCategory(tid, lang, token).ToList();

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
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            #endregion XML
        #endregion Get Resource By TopCategory ID


        #region Get Resource By Search Keywords
            #region JSON
            //Friendly
            /// <summary>
            /// Get allowable resource list by using interest key word(s). Format in JSON.
            /// </summary>
            /// <param name="kws">interest key words to be searched. Multiple interesting kords could be split by using Space, comma, semicolon</param>
            /// <param name="lang">Language. English = "en"; French = "fr"</param>
            /// <param name="token">Access token</param>
            /// <returns>Return resource list. Returned resource includes any interest search key words or their synonym in his name, description, location, term, category etc. Format in JSON</returns>
            [ActionName("search")]
            [Route("api/v2/resource/kws/json/{token}/{lang}/{kws}")]
            [Route("api/v2/Ressource/kws/json/{token}/{lang}/{kws}")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage search(string kws, string lang, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = resourceservice.GetResourceByKeywords(kws, lang, token).ToList();
                return toJson(json, lang);
            }
            //Query String
            /// <summary>
            /// Query String style pass interest keyword(s), response allowable JSON resource list.  
            /// </summary>
            /// <param name="kws">interest key words to be search. Multiple interesting kords could be split by using Space, comma, semicolon</param>
            /// <param name="lang">Language. English = "en"; French = "fr"</param>
            /// <param name="token">Access token</param>
            /// <returns>Return resource list. Returned resource includes any interest search key words or their synonym in his name, description, location, term, category etc. Format in JSON</returns>
            [ActionName("search")]
            [Route("api/v2/resource/kws/json")]
            [Route("api/v2/Ressource/kws/json")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage search_QS(string lang, string kws, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = resourceservice.GetResourceByKeywords(kws, lang, token).ToList();
                return toJson(json, lang);
            }
            #endregion JSON

            #region XML
            //Friendly
            /// <summary>
            /// Get XML format allowable resource list by using interest key word(s). 
            /// </summary>
            /// <param name="kws">interest key words to be search. Multiple interesting kords could be split by using Space, comma, semicolon</param>
            /// <param name="lang">Language. English = "en"; French = "fr"</param>
            /// <param name="token">Access token</param>
            /// <returns>Return resource list. Returned resource includes any interest search key words or their synonym in his name, description, location, term, category etc. Format in XML</returns>
            [ActionName("xml")]
            [Route("api/v2/resource/kws/xml/{token}/{lang}/{kws}")]
            [Route("api/v2/Ressource/kws/xml/{token}/{lang}/{kws}")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage search_XML(string lang, string kws, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                return createSearchResult(kws, lang, token);
            }
            //Query String
            /// <summary>
            /// Query String style pass interest keyword(s), response XML fromat allowable resource list. 
            /// </summary>
            /// <param name="kws">interest key words to be search. Multiple interesting kords could be split by using Space, comma, semicolon</param>
            /// <param name="lang">Language. English = "en"; French = "fr"</param>
            /// <param name="token">Access token</param>
            /// <returns>Return resource list. Returned resource includes any interest search key words or their synonym in his name, description, location, term, category etc. Format in XML</returns>
            [ActionName("xml")]
            [Route("api/v2/resource/kws/xml")]
            [Route("api/v2/Ressource/kws/xml")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage search_XML_QS(string lang, string kws, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                return createSearchResult(kws, lang, token);
            }
            #endregion XML

            private HttpResponseMessage createSearchResult(string kws, string lang, string token)
            {
                lang = lang.ToLower();
                if ((lang == "en") || (lang == "fr"))
                {
                    var xml = resourceservice.GetResourceByKeywords(kws, lang, token).ToList();

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
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }

        #endregion Get Resource By Search Keywords


        #region Proc_Get_All_Resources_In_Radius
            #region JSON
            //Friendly
            /// <summary>
            /// Get allowable resources which locate in a circular area. current location is center of the circle; radius (Km) is distance. 
            /// </summary>
            /// <param name="lang">Language: English = "en" ;  French = "fr"</param>
            /// <param name="lat">Latitude of current location </param>
            /// <param name="lon">Longitude of current location </param>
            /// <param name="radius">radius: How many Kilometre from current location</param>
            /// <param name="token">Access token</param>
            /// <returns>Return a resource list in a circular area, current location is center, radius  is the distance,fromat in JSON </returns>
            [ActionName("json")]
            [Route("api/v2/resource/circular/json/{token}/{lang}/{lat}/{lon}/{radius}")]
            [Route("api/v2/Ressource/circulaire/json/{token}/{lang}/{lat}/{lon}/{radius}")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage GetResourcesInRadiusList(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = resourceservice.GetResourcesInRadiusList(lang, lat, lon, radius, token).ToList();
                return toJson(json, lang);
            }

            //Query String
            /// <summary>
            /// Query String style, get allowable resources which locate in a circular area. current location is center of the circle; radius (Km) is distance. 
            /// </summary>
            /// <param name="lang">Language: English = "en" ;  French = "fr"</param>
            /// <param name="lat">Latitude of current location</param>
            /// <param name="lon">Longitude of current location</param>
            /// <param name="radius">radius: How many Kilometre from current location</param>
            /// <param name="token">Access token</param>
            /// <returns>Return a resource list in a circular area, current location is center, radius is the distance, fromat in JSON </returns>
            [ActionName("json")]
            [Route("api/v2/resource/circular/json")]
            [Route("api/v2/Ressource/circulaire/json")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage GetResourcesInRadiusList_QS(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = resourceservice.GetResourcesInRadiusList(lang, lat, lon, radius, token).ToList();
                return toJson(json, lang);
            }
            #endregion JSON

            #region XML
            //Friendly
            /// <summary>
            /// Get allowable resources which locate in a circular area. current location is center of the circle; radius (Km) is distance. 
            /// </summary>
            /// <param name="lang">Language: English = "en" ;  French = "fr"</param>
            /// <param name="lat">Latitude of current location </param>
            /// <param name="lon">Longitude of current location </param>
            /// <param name="radius">radius: How many Kilometre from current location</param>
            /// <param name="token">Access token</param>
            /// <returns>Return a resource list, current location is center, wish distance is the radius, fromat in XML </returns>
            [ActionName("xml")]
            [Route("api/v2/resource/circular/xml/{token}/{lang}/{lat}/{lon}/{radius}")]
            [Route("api/v2/Ressource/circulaire/xml/{token}/{lang}/{lat}/{lon}/{radius}")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage GetResourcesInRadiusList_XML(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                return createCircularResult(lang, lat, lon, radius, token);
            }

            //Query String
            /// <summary>
            /// Query String style, get allowable resources which locate in a circular area. current location is center of the circle; radius (Km) is distance. 
            /// </summary>
            /// <param name="lang">Language: English = "en" ;  French = "fr"</param>
            /// <param name="lat">Latitude of current location</param>
            /// <param name="lon">Longitude of current location</param>
            /// <param name="radius">radius: How many Kilometre from current location</param>
            /// <param name="token">Access token</param>
            /// <returns>Return a resource list, current location is center, wish distance is the radius, fromat in XML</returns>
            [ActionName("xml")]
            [Route("api/v2/resource/circular/xml")]
            [Route("api/v2/Ressource/circulaire/xml")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage GetResourcesInRadiusList_XML_QS(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                return createCircularResult(lang, lat, lon, radius, token);
            }
            #endregion XML
            private HttpResponseMessage createCircularResult(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                lang = lang.ToLower();
                if ((lang == "en") || (lang == "fr"))
                {
                    var xml = resourceservice.GetResourcesInRadiusList(lang, lat, lon, radius, token).ToList();

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
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }


        #endregion Proc_Get_All_Resources_In_Radius


        #region Proc_Get_All_Resource_In_Radius_boundary_Box
            #region JSON
            //Friendly
            /// <summary>
            /// Get allowable resources which locate in a Boundary-Box area. current location is center of the boundary box; Radius (Km) is center to Northern, Southern, Eastern and Western boundary. 
            /// </summary>
            /// <param name="lang">Language: English = "en" ;  French = "fr"</param>
            /// <param name="lat">Latitude of current location </param>
            /// <param name="lon">Longitude of current location </param>
            /// <param name="radius">radius: How many Kilometre from current location</param>
            /// <param name="token">Access token</param>
            /// <returns>Return a resource list in Boundary-Box area, current location is center. Radius (Km) is the distance to Northern, Southern, Eastern and Western, fromat in JSON </returns>
            [ActionName("json")]
            [Route("api/v2/resource/box/json/{token}/{lang}/{lat}/{lon}/{radius}")]
            [Route("api/v2/Ressource/boîte/json/{token}/{lang}/{lat}/{lon}/{radius}")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage GetResourcesInBoxList(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                var json = resourceservice.GetResourcesInRadiusBoundaryBoxList(lang, lat, lon, radius, token).ToList();
                return toJson(json, lang);
            }

            //Query String
            /// <summary>
            /// Query String style, get allowable resources which locate in a Boundary-Box area. current location is center of the boundary box; Radius (Km) is center to Northern, Southern, Eastern and Western boundary.  
            /// </summary>
            /// <param name="lang">Language: English = "en" ;  French = "fr"</param>
            /// <param name="lat">Latitude of current location</param>
            /// <param name="lon">Longitude of current location</param>
            /// <param name="radius">radius: How many Kilometre from current location</param>
            /// <param name="token">Access token</param>
            /// <returns>Return a resource list in Boundary-Box area, current location is center. Radius (Km) is the distance to Northern, Southern, Eastern and Western, fromat in JSON </returns>
            [ActionName("json")]
            [Route("api/v2/resource/box/json")]
            [Route("api/v2/Ressource/boîte/json")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage GetResourcesInBoxList_QS(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                var json = resourceservice.GetResourcesInRadiusBoundaryBoxList(lang, lat, lon, radius, token).ToList();
                return toJson(json, lang);
            }
            #endregion JSON

            #region XML
            //Friendly
            /// <summary>
            /// Get allowable resources which locate in a Boundary-Box area. current location is center of the boundary box; Radius (Km) is center to Northern, Southern, Eastern and Western boundary.  
            /// </summary>
            /// <param name="lang">Language: English = "en" ;  French = "fr"</param>
            /// <param name="lat">Latitude of current location </param>
            /// <param name="lon">Longitude of current location </param>
            /// <param name="radius">radius: How many Kilometre from current location</param>
            /// <param name="token">Access token</param>
            /// <returns>Return a resource list in Boundary-Box area, current location is center. Radius (Km) is the distance to Northern, Southern, Eastern and Western, ,fromat in XML </returns>
            [ActionName("xml")]
            [Route("api/v2/resource/box/xml/{token}/{lang}/{lat}/{lon}/{radius}")]
            [Route("api/v2/Ressource/boîte/xml/{token}/{lang}/{lat}/{lon}/{radius}")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage GetResourcesInBoxList_XML(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                return createBoxResult(lang, lat, lon, radius, token);
            }

            //Query String
            /// <summary>
            /// Query String style, get allowable resources which locate in a Boundary-Box area. current location is center of the boundary box; Radius (Km) is center to Northern, Southern, Eastern and Western boundary.   
            /// </summary>
            /// <param name="lang">Language: English = "en" ;  French = "fr"</param>
            /// <param name="lat">Latitude of current location</param>
            /// <param name="lon">Longitude of current location</param>
            /// <param name="radius">radius: How many Kilometre from current location</param>
            /// <param name="token">Access token</param>
            /// <returns>Return a resource list in Boundary-Box area, current location is center. Radius (Km) is the distance to Northern, Southern, Eastern and Western, fromat in XML</returns>
            [ActionName("xml")]
            [Route("api/v2/resource/box/xml")]
            [Route("api/v2/Ressource/boîte/xml")]
            [ResponseType(typeof(RamResource))]
            [HttpGet]
            public HttpResponseMessage GetResourcesInBoxList_XML_QS(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                return createBoxResult(lang, lat, lon, radius, token);
            }
            #endregion XML
            private HttpResponseMessage createBoxResult(string lang, decimal lat, decimal lon, decimal radius, string token)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                lang = lang.ToLower();
                if ((lang == "en") || (lang == "fr"))
                {
                    var xml = resourceservice.GetResourcesInRadiusBoundaryBoxList(lang, lat, lon, radius, token).ToList();

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
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
        #endregion Proc_Get_All_Resource_In_Radius_boundary_Box




        #region Search Resource by Coverage
        #region JSON
        // Friendly
        /// <summary>
        ///  Get allowable resources by its coverage   
        /// </summary>
        /// <param name="lang">language. English = "en"; French = "fr"</param>
        /// <param name="coverage">coverage</param>
        /// <param name="token">Access token</param>
        /// <returns>return a JSON format resource list</returns>
        [ActionName("json")]
        [Route("api/v2/resource/coverage/json/{token}/{lang}/{coverage}")]
        [Route("api/v2/Ressource/couverture/json/{token}/{lang}/{coverage}")]
        [ResponseType(typeof(RamResource))]
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByCoverage(string lang, string coverage, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = resourceservice.GetResourceByCoverage(coverage, lang, token).ToList();
            return toJson(json, lang);
        }
        // Query String
        /// <summary>
        ///  Query String style get resources by its coverage   
        /// </summary>
        /// <param name="lang">language. English = "en"; French = "fr"</param>
        /// <param name="coverage">coverage</param>
        /// <param name="token">Access token</param>
        /// <returns>return a XML format resource list</returns>
        [ActionName("json")]
        [Route("api/v2/resource/coverage/json")]
        [Route("api/v2/Ressource/couverture/json")]
        [ResponseType(typeof(RamResource))]
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByCoverage_QS(string lang, string coverage, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            var json = resourceservice.GetResourceByCoverage(coverage, lang, token).ToList();
            return toJson(json, lang);
        }
        #endregion JSON

        #region XML
        // Friendly
        /// <summary>
        ///  Get resources by its coverage 
        /// </summary>
        /// <param name="lang">language. English = "en"; French = "fr"</param>
        /// <param name="coverage">coverage</param>
        /// <param name="token">Access token</param>
        /// <returns>return a XML format resource list</returns>
        [ActionName("xml")]
        [Route("api/v2/resource/coverage/xml/{token}/{lang}/{coverage}")]
        [Route("api/v2/Ressource/couverture/xml/{token}/{lang}/{coverage}")]
        [ResponseType(typeof(RamResource))]
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByProvince_XML(string lang, string coverage, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            return createResourcesByCoverageResult(coverage, lang, token);
        }
        // Query String
        /// <summary>
        ///  Query String style get resources in single province filter by resource's language 
        /// </summary>
        /// <param name="lang">language. English = "en"; French = "fr"</param>
        /// <param name="coverage">Coverage</param>
        /// <param name="token">Access token</param>
        /// <returns>return a XML format resource list located in a specific province</returns>
        [ActionName("xml")]
        [Route("api/v2/resource/coverage/xml")]
        [Route("api/v2/Ressource/couverture/xml")]
        [ResponseType(typeof(RamResource))]
        [HttpGet]
        public HttpResponseMessage GetAllResourcesByCoverage_XML_QS(string lang, string coverage, string token)
        {
            HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
            return createResourcesByCoverageResult(coverage, lang, token);
        }
        private HttpResponseMessage createResourcesByCoverageResult(string coverage, string lang, string token)
        {
            lang = lang.ToLower();
            if ((lang == "en") || (lang == "fr"))
            {
                var xml = resourceservice.GetResourceByCoverage(coverage, lang, token).ToList();

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
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
        #endregion XML

        #endregion Search Resource by Coverage


        private HttpResponseMessage toJson(Object r, string lang)
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                lang = lang.ToLower();
                if ((lang == "en") || (lang == "fr"))
                {
                    string thisJson = JsonConvert.SerializeObject(r, Formatting.None);

                    if (thisJson.Length < 5)
                    {
                        var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
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
                else
                {
                    var response = this.Request.CreateResponse(HttpStatusCode.NotFound);
                    response.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                    return response;
                }

            }
    }
}
