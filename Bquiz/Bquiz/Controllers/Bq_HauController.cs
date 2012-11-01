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
            var group = db.bq_QuestionGroup_GetById(groupId).Single();
            var questionList = db.bq_Question_GetByQuestionGroupId(group.QuestionGroupId).ToList();

            bq_part1 part1 = new bq_part1();
            part1.Group = group;
            part1.QuestionList = questionList;
            return View();
        }


        //Viết vào cái này nhé
        [HttpPost]
        public ActionResult UpdatePart1(bq_part1 part1)
        {
            if (ModelState.IsValid)
            {
                db.bq_QuestionGroup_Update(
                    part1.Group.QuestionGroupId,
                    part1.Group.Name,
                    part1.Group.Order,
                    part1.Group.Paragraph,
                    part1.Group.MediaPath);

                foreach (var question in part1.QuestionList)
                {
                    db.bq_Question_Update(
                        question.QuestionId,
                        question.Order,
                        question.ImagePath,
                        question.MediaPath,
                        question.Paragraph,
                        question.OptionA,
                        question.OptionB,
                        question.OptionC,
                        question.OptionD,
                        question.Answer);
                }

                //Trả về trang chủ
                return Redirect("/");
            }
            else 
                return View();
        }
    }
}
