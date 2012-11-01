using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bquiz.Models;

namespace Bquiz.Controllers
{
    public class Bq_TuCuongController : Controller
    {
        BluequizEntities db = new BluequizEntities();

        //
        // GET: /Bq_TuCuong - có thể lấy cái này làm mẫu

        public ActionResult Index()
        {
            return View();
        }

        //Cái hàm này như là hàm khởi tạo, chỉ chạy 1 lần mỗi khi tạo một quiz mới
        //Nhiệm vụ : Để insert vào database số lượng câu hỏi của từng questionGroup.
        //Sau đó chúng ta sẽ cập nhật lại để đảm bảo tính đúng đắn của bộ câu hỏi.
        //Có thể xem thêm "http://localhost:12347/Bq_TuCuong/UpdatePart8?groupId=c38d171e-524b-466e-b814-be1d78398f7c" 
        //để hiểu nó hoạt động như thế nào
        public ActionResult NewPart8(Guid quizId) //Tất cả cái add đều phải có một cái quizId
        {
            for (byte i = 0; i < 4; i++)
            {
                //4 pairs of reading texts with 5 questions per pair
                var questionGroupId = Guid.NewGuid();
                db.bq_QuestionGroup_Add(
                    questionGroupId,
                    quizId,
                    8, //Thay đổi đối với từng part
                    String.Format("Part8.{0}", i + 1),
                    i,
                    null, null);

                //Create 5 question each a group
                for (byte ord = 0; ord < 5; ord++)
                {
                    db.bq_Question_Add(
                        Guid.NewGuid(),
                        questionGroupId,
                        quizId,
                        ord,
                        null, null, null, null, null, null, null, 0);
                }

            }

            //return RedirectToAction("UpdatePart8", new { quizId = quizId, step = 0 });
            return Redirect(String.Format("/QuestionGroup?quizId={0}&part=8", quizId));
        }

        //Hiển thị bộ câu hỏi để cập nhật
        public ActionResult UpdatePart8(Guid groupId)
        {
            var group = db.bq_QuestionGroup_GetById(groupId).Single();
            var questionList = db.bq_Question_GetByQuestionGroupId(group.QuestionGroupId).ToList();

            bq_Part8 part8 = new bq_Part8();
            part8.Group = group;
            part8.QuestionList = questionList;

            return View(part8);
        }

        //Xử lý dữ liệu từ client
        [HttpPost]
        public ActionResult UpdatePart8(bq_Part8 part8)
        {
            if (ModelState.IsValid)
            {
                db.bq_QuestionGroup_Update(
                    part8.Group.QuestionGroupId,
                    part8.Group.Name,
                    part8.Group.Order,
                    part8.Group.Paragraph,
                    part8.Group.MediaPath);

                foreach (var question in part8.QuestionList)
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
            {
                //Nếu như dữ liệu gởi lên không đạt yêu cầu
                //Trả về client trạng thái dữ liệu đang làm dở
                return View(part8);
            }
        }

    }
}
