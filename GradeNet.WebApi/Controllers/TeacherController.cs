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

        [HttpGet]
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

        [HttpGet]
        public ActionResult AddGrade(int studentId, int lessonId)
        {
            var model = new AddGradeViewModel();
            model.LessonId = 1;
            model.LessonName = "Matematyka";
            model.Student = new StudentViewModel(studentId, "Andrzej", null, "Nazwisko");

            return View(model);
        }

        [HttpPost]
        public ActionResult AddGrade(int studentId, int lessonId, string grade, string style, string semester)
        {
            var model = new AddGradeViewModel();
            model.LessonId = 1;
            model.LessonName = "Matematyka";
            model.Student = new StudentViewModel(studentId, "Andrzej", null, "Nazwisko");

            var isCorrect = false;
            ViewBag.Error = "Błędne dane!";

            if (isCorrect)
                return View("Lesson", _teacherManager.GetLessonView(lessonId, 0));
            else
                return View(model);
        }

        [HttpGet]
        public ActionResult SelectStudentFromClass(int classId)
        {
            ViewBag.ClassId = classId;
            var studentsList = _teacherManager.StudentsGet(classId);

            return View(studentsList);
        }

        [HttpGet]
        public ActionResult StudentsComments(int studentId, int classId)
        {
            ViewBag.ClassId = classId;
            var commentsList = _teacherManager.StudentsCommentsGet(studentId);

            return View(commentsList);
        }

        [HttpGet]
        public ActionResult EditComment(int studentId, int commentId, int classId)
        {
            ViewBag.ClassId = classId;
            //var commentsList = _teacherManager.StudentsCommentsGet(studentId);

            var commentsList = _teacherManager.StudentsCommentsGet(studentId);

            return View("StudentsComments", commentsList);
        }

        [HttpGet]
        public ActionResult DeleteComment(int studentId, int commentId, int classId)
        {
            ViewBag.ClassId = classId;
            //var commentsList = _teacherManager.StudentsCommentsGet(studentId);

            var commentsList = _teacherManager.StudentsCommentsGet(studentId);

            return View("StudentsComments", commentsList);
        }
    }
}