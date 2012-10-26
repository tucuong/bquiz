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

        public ActionResult Index(Guid partId)
        {
            var questionGroups = db.bq_QuestionGroup_GetByPart(partId).ToList();
            return View(questionGroups);
        }

    }
}
