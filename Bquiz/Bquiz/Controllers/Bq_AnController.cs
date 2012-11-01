using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bquiz.Models;

namespace Bquiz.Controllers
{
    public class Bq_AnController : Controller
    {
        BluequizEntities db = new BluequizEntities();

        //
        // GET: /Bq_An/

        public ActionResult Index()
        {
            return View();
        }

        //Viết vào cái này nhé
        public ActionResult UpdatePart3(Guid groupId)
        {
            return View();
        }


        //Viết vào cái này nhé
        public ActionResult UpdatePart4(Guid groupId)
        {
            return View();
        }
    }
}
