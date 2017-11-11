using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DATA.EF;

namespace BIZ.Survey
{
    public class suveryServices
    {
        private RAMEntities db = new RAMEntities();

        public void insertSurvey(string token, int? surveryQuestionID, int? chatid, string surveyAnswer, string language, string surveyAnswer_Device)
        {
            try
            {
             db.Proc_Insert_Answer(token,  surveryQuestionID, chatid, surveyAnswer,language,surveyAnswer_Device );
            }
            catch
            {

            }


        }
    }
}