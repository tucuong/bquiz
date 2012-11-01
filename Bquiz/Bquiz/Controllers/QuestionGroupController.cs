using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bquiz.Models;

namespace Bquiz.Controllers
{
    public class QuestionGroupController : Controller
    {
        BluequizEntities db = new BluequizEntities();

        //
        // GET: /QuestionGroup/

        public ActionResult Index(Guid quizId, byte partId)
        {
            var part = db.bq_Part_GetById(partId).Single();
            var questionGroups = db.bq_QuestionGroup_GetByQuiz(quizId, partId).ToList();

            ViewBag.Part = part;
            return View(questionGroups);
        }

    }
}
