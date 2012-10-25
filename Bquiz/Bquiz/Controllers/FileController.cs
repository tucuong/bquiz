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
