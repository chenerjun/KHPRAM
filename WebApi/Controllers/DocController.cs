using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    public class DocController : Controller
    {
        // GET: Doc

        [AuthorizeIPAddress]
        [FilterIP]
        public ActionResult Index()
        {
            return View();
        }
    }
}