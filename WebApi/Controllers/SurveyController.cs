using BIZ.Survey;
using BIZ.Log;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Filters;
using System.Collections.Generic;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    /// <summary>
    /// Receiving user's Survey answer
    /// </summary>
    public class SurveyController : ApiController
    {
        HttpResponseMessage response = new HttpResponseMessage();
        HttpRequest request = HttpContext.Current.Request;
        LogServices logservices = new LogServices();
        suveryServices ss = new suveryServices();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_survey">surveyType_ID: 1=Pre Survey; 2=Post Survey ; _surveyQuestion_ID; _chatid</param>
        /// <returns></returns>
        [ResponseType(typeof(answer))]
        [Route("api/v2/survey/answer")]
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "post")]
        public HttpResponseMessage answer([FromBody]ChatSurvey _survey)
        {
            bool result = false;

            int _chatid = 0;
            string _language = "";
            string _surveyAnswer_Device = "";
            string _token = "";

            List<answer> _answer = _survey.chatsurvey;
            int _surveyQuestion_ID = 0;
            string _surveyAnswer = "";

            try
            {
                _chatid = _survey.chatID;
                _language = _survey.language;
                _surveyAnswer_Device = _survey.surveyAnswer_Device;
                _token = _survey.token;

                foreach (answer _a in _answer)
                {
                    _surveyQuestion_ID = _a.surveyQuestion_ID;
                    _surveyAnswer = _a.surveyAnswer;

                    ss.insertSurvey(_token,  _surveyQuestion_ID, _chatid, _surveyAnswer, _language, _surveyAnswer_Device);

                    result = true;
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

            if (result)
            {
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent("\"status\":\"OK\"", Encoding.UTF8);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

                //( request,  response,  dbschema, format,  para,  lang, token, string cscontent,  csendpoint, keywords)
                 logservices.logservices(request, response, "survey", "json", "path", _language, _token, "answer", "survey", _chatid+"");


                return response;
            }
            else
            {
                var response = this.Request.CreateResponse(HttpStatusCode.NotFound);
                response.Content = new StringContent("\"status\":\"Failed\"", Encoding.UTF8);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");


                logservices.logservices(request, response, "survey", "json", "path", _language, _token, "answer", "survey", _chatid + "");

                return response;
            }

        }
    }
}
