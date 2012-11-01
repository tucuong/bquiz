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
            var parts = db.bq_Part_GetByParentId(0).ToList();

            ViewBag.QuizId = quizId;
            return View(parts);
        }

        public ActionResult EdittingMenu(Guid? quizId)
        {
            if (!quizId.HasValue)
                quizId = Guid.Parse("55A0C125-226C-454D-B8D9-D70E8E75045E");

            var parts = db.bq_Part_GetAllChilds().ToList();
            ViewBag.QuizId = quizId;

            return View(parts);
        }

    }
}
