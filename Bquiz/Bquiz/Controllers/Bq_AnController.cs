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
        public ActionResult NewPart3(Guid quizId)
        {
            for (byte i = 0; i < 10; i++)
            {
                //4 pairs of reading texts with 10 questions per pair
                var questionGroupId = Guid.NewGuid();
                db.bq_QuestionGroup_Add(
                    questionGroupId,
                    quizId,
                    3, //Thay đổi đối với từng part (thứ tự part)
                    String.Format("Part3.{0}-{1}", 40+i + 1,(i+1)*4+3),
                    i,
                    null, null);

                //Create 3 question each a group
                for (byte ord = 0; ord < 3; ord++)
                {
                    db.bq_Question_Add(
                        Guid.NewGuid(),
                        questionGroupId, //phải trả về đúng với group id phía trên
                        quizId,
                        ord,
                        null, null, null, null, null, null, null, 0);
                }

            }

            //return RedirectToAction("UpdatePart8", new { quizId = quizId, step = 0 });
            return Redirect(String.Format("/QuestionGroup?quizId={0}&part=3", quizId));
        }

        //Viết vào cái này nhé
        public ActionResult UpdatePart3(Guid groupId)
        {
            var group = db.bq_QuestionGroup_GetById(groupId).Single();
            var questionList = db.bq_Question_GetByQuestionGroupId(group.QuestionGroupId).ToList();

            bq_Part8 part3 = new bq_Part8();
            part3.Group = group;
            part3.QuestionList = questionList;

            return View(part3);
            
        }

        public ActionResult NewPart4(Guid quizId)
        {
            for (byte i = 0; i < 10; i++)
            {
                //4 pairs of reading texts with 10 questions per pair
                var questionGroupId = Guid.NewGuid();
                db.bq_QuestionGroup_Add(
                    questionGroupId,
                    quizId,
                    3, //Thay đổi đối với từng part (thứ tự part)
                    String.Format("Part4.{0}", i + 1),
                    i,
                    null, null);

                //Create 3 question each a group
                for (byte ord = 0; ord < 3; ord++)
                {
                    db.bq_Question_Add(
                        Guid.NewGuid(),
                        questionGroupId, //phải trả về đúng với group id phía trên
                        quizId,
                        ord,
                        null, null, null, null, null, null, null, 0);
                }

            }

            //return RedirectToAction("UpdatePart4", new { quizId = quizId, step = 0 });
            return Redirect(String.Format("/QuestionGroup?quizId={0}&part=4", quizId));
        }
        //Update Part4
        public ActionResult UpdatePart4(Guid groupId)
        {
            //var group = db.bq_QuestionGroup_GetById(groupId).Single();
            //var questionList = db.bq_Question_GetByQuestionGroupId(group.QuestionGroupId).ToList();

            //bq_Part4 part4 = new bq_Part4();
            //part4.Group = group;
            //part4.QuestionList = questionList;

            //return View(part4);
            return View();
           
        }

        //Xử lý từ phía Client

        //public ActionResult UpdatePart3(bq_Part3 part3)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.bq_QuestionGroup_Update(
        //            part3.Group.QuestionGroupId,
        //            part3.Group.Name,
        //            part3.Group.Order,
        //            part3.Group.Paragraph,
        //            part3.Group.MediaPath);

        //        foreach (var question in part3.QuestionList)
        //        {
        //            db.bq_Question_Update(
        //                question.QuestionId,
        //                question.Order,
        //                question.ImagePath,
        //                question.MediaPath,
        //                question.Paragraph,
        //                question.OptionA,
        //                question.OptionB,
        //                question.OptionC,
        //                question.OptionD,
        //                question.Answer);
        //        }

        //        //Trả về trang chủ
        //        return Redirect("/");
        //    }
        //    else
        //    {
        //        //Nếu như dữ liệu gởi lên không đạt yêu cầu
        //        //Trả về client trạng thái dữ liệu đang làm dở
        //        return View(part3);
        //    }
        //}
        
}

    
}
