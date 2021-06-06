using GradeNet.Infrastructure.Helpers;
using GradeNet.Infrastructure.Interfaces;
using GradeNet.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GradeNet.WebApi.Controllers
{
    [Authorize]
    public class SchoolController : Controller
    {
        private readonly ISchoolManager _schoolManager;
        private readonly IHtmlRenderHelper _HtmlRenderHelper;

        public SchoolController(ISchoolManager schoolManager, IHtmlRenderHelper HtmlRenderHelper)
        {
            _schoolManager = schoolManager;
            _HtmlRenderHelper = HtmlRenderHelper;
        }

        public ActionResult Main()
        {
            var years = _schoolManager.YearsGet();

            return View(years);
        }

        [HttpPost]
        public JsonResult HtmlForClassSelectGet(int year)
        {
            string content = _HtmlRenderHelper.HtmlForClassSelectGet(year);
            return Json(new { content = content });
        }

        [HttpPost]
        public JsonResult HtmlForStudentsListGet(int classId)
        {
            string content = _HtmlRenderHelper.HtmlForStudentsListGet(classId);
            return Json(new { content = content });
        }

        [HttpPost]
        public JsonResult HtmlForLessonSelectGet(int classId)
        {
            string content = _HtmlRenderHelper.HtmlForLessonSelectGet(classId);
            return Json(new { content = content });
        }

        [HttpPost]
        public JsonResult HtmlForPreviewSelectGet(bool lessonIsChosen)
        {
            string content = _HtmlRenderHelper.HtmlForPreviewSelectGet(lessonIsChosen);
            return Json(new { content = content });
        }

        [HttpPost]
        public JsonResult HtmlForPreview(int classId, int lessonId, int previewType)
        {
            string content = _HtmlRenderHelper.HtmlForPreviewGet(classId, lessonId, previewType);
            return Json(new { content = content });
        }

        public ActionResult xx()
        {
            var years = _schoolManager.YearsGet();

            return View(years);
        }
    }
}