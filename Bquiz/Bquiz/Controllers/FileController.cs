using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Bquiz.Models;
using System.IO;

namespace Bquiz.Controllers
{
    public class FileController : Controller
    {
        BluequizEntities db = new BluequizEntities();

        //
        // GET: /File/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadAudio(Guid? quizId)
        {
            //Trong quá trình thử nghiệm nên anh lấy cái quizId có sẵn luôn cho tiện
            //Sau này sẽ thay cái này bằng quizId chính thức.
            if (!quizId.HasValue)
                quizId = Guid.Parse("55A0C125-226C-454D-B8D9-D70E8E75045E");

            //Tạo Part
            Guid partId = Guid.NewGuid();
            db.bq_Part_Add(partId, quizId, "Single Passages", 7);

            //Tạo questionGroup nơi chứa những bộ câu hỏi, và audio file, hình ảnh...
            Guid questionGroupId = Guid.NewGuid();
            db.bq_QuestionGroup_Add(questionGroupId, quizId, partId, "Part7.153-155", 1, null, null);

            ViewBag.QuestionGroupId = questionGroupId;
            return View();
        }


        //file's limit : 10MB
        public ActionResult UploadQuestionGroupAudio(IEnumerable<HttpPostedFileBase> attachments, Guid questionGroupId)
        {
            // The Name of the Upload component is "attachments" 
            foreach (var file in attachments)
            {
                // Some browsers send file names with full path. We only care about the file name.
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var destinationPath = Path.Combine(Server.MapPath("~/Content/Audio"), fileName);

                file.SaveAs(destinationPath);
                db.bq_QuestionGroup_UpdateMediaPath(questionGroupId, fileName);
            }

            // Return an empty string to signify success
            return Content("");
        }

    }
}
