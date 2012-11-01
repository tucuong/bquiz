using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bquiz.Models;

namespace Bquiz.Controllers
{
    public class Bq_TienController : Controller
    {
        BluequizEntities db = new BluequizEntities();

        //
        // GET: /Bq_Tien/

        public ActionResult Index()
        {
            return View();
        }

        //Viết vào cái này nhé
        public ActionResult UpdatePart5(Guid groupId)
        {
            return View();
        }


        //Viết vào cái này nhé
        public ActionResult UpdatePart6(Guid groupId)
        {
            return View();
        }
    }
}
