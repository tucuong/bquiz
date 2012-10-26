using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bquiz.Models;

namespace Bquiz.Controllers
{
    public class PartController : Controller
    {
        BluequizEntities db = new BluequizEntities();

        //
        // GET: /Part/

        public ActionResult Index(Guid quizId)
        {
            var parts = db.bq_Part_GetByQuizId(quizId).ToList();
            return View(parts);
        }

    }
}
