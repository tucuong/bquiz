using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bquiz.Models;

namespace Bquiz.Controllers
{
    public class QuizController : Controller
    {
        BluequizEntities db = new BluequizEntities();

        //
        // GET: /Quiz/

        public ActionResult Index()
        {
            var quizs = db.bq_Quiz.ToList();
            return View(quizs);
        }

    }
}
