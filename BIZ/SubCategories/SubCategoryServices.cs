using DATA.EF;
using System.Collections.Generic;
using System.Linq;

namespace BIZ.SubCategories
{
    public class SubCategoryServices
    {
        private RAMEntities db = new RAMEntities();

        public List<SubCategoryResult> GetAllSubCategories(string lang, string token)
        {
            var response = db.Proc_Get_SubCategory(lang, token).ToList();

            return response;

        }


        public SubCategoryResult GetSubcategoryBySID(int sid, string lang, string token)
        {
            var response = db.Proc_Get_SubCategory_by_SId(sid, lang, token).FirstOrDefault();

            return response;
        }


        public List<SubCategoryResult> GetSubcategoryByTopID(int Tid, string lang, string token)
        {
            var response = db.Proc_Get_SubCategory_byTopCategory(Tid, lang, token).ToList();

            return response;
        }
    }
}