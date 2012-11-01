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

        public ActionResult NewPart1(Guid? quizId) //Tất cả cái add đều phải có một cái quizId
        {
            if (!quizId.HasValue)
                quizId = Guid.Parse("55A0C125-226C-454D-B8D9-D70E8E75045E");

            var questionGroupId = Guid.NewGuid();
            db.bq_QuestionGroup_Add(
                    questionGroupId,
                    quizId,
                    1, //Thay đổi đối với từng part
                    String.Format("Part1.1-5"),
                    1,
                    null, null);

            //return RedirectToAction("UpdatePart8", new { quizId = quizId, step = 0 });
            return Redirect("/");
        }

        //Viết vào cái này nhé
        public ActionResult UpdatePart1(Guid groupId)
        {
            return View();
        }


        //Viết vào cái này nhé
        public ActionResult UpdatePart2s(Guid groupId)
        {
            return View();
        }
    }
}
