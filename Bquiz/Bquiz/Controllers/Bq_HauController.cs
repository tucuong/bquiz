using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bquiz.Models;

namespace Bquiz.Controllers
{
    public class Bq_HauController : Controller
    {
        BluequizEntities db = new BluequizEntities();

        //
        // GET: /Bq_Hau/

        public ActionResult Index()
        {
            return View();
        }

        //Viết vào cái này nhé
        public ActionResult UpdatePart1(Guid groupId)
        {
            return View();
        }


        //Viết vào cái này nhé
        public ActionResult UpdatePart2(Guid groupId)
        {
            return View();
        }
    }
}
