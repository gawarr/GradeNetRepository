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
    public class TeacherController : Controller
    {
        private readonly ITeacherManager _teacherManager;

        public TeacherController(ITeacherManager teacherManager)
        {
            _teacherManager = teacherManager;
        }

        public ActionResult FindClass()
        {
            var years = _teacherManager.YearsGet();
            return View(years);
        }

        [HttpPost]
        public JsonResult GetHtmlForClassSelect(int year)
        {
            string html = _teacherManager.GetHtmlForClassSelect(year);
            return Json(new { html = html});
        }

        [HttpPost]
        public ActionResult Class(int classId)
        {
            var classVM = _teacherManager.ClassGet(classId);
            return View(classVM);
        }

        public ActionResult SelectLesson(int classId)
        {
            var lessons = _teacherManager.LessonsGet_ForClass(classId);
            return View(lessons);
        }

        [HttpGet]
        public ActionResult Lesson(int lessonId, int previewTypeId = 0)
        {
            var lessonVm = _teacherManager.GetLessonView(lessonId, previewTypeId);

            return View(lessonVm);
        }
    }
}