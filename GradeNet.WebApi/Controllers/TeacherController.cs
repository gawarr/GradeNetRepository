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
    [Authorize(Roles = "Teacher")]
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
        public ActionResult AddGrade(int studentId, string studentName, int lessonId, int classId)
        {
            var model = new AddGradeViewModel();

            model.StudentId = studentId;
            model.StudentName = studentName;

            model.LessonId = lessonId;
            var lesson = _teacherManager.LessonGet(lessonId);
            model.LessonName = lesson.LessonName;

            model.ClassId = classId;

            return View(model);
        }

        [HttpPost]
        public ActionResult AddGrade(int studentId, string studentName, int lessonId, string lessonName, string grade, int style, string semester, int classId)
        {
            var model = new AddGradeViewModel();

            model.StudentId = studentId;
            model.StudentName = studentName;

            model.LessonId = lessonId;
            model.LessonName = lessonName;

            model.ClassId = classId;

            string teacherEmail = User.Identity.Name;

            var isCorrect = _teacherManager.GradeAdd(grade, semester, style, studentId, lessonId, teacherEmail);

            if (isCorrect)
            {
                ViewBag.Info = "Dodano ocenę";
                return View("Lesson", _teacherManager.GetLessonView(lessonId, 0));
            }
            else
            {
                ViewBag.Info = "Błąd przy dodawaniu oceny";
                return View(model);
            }
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

        [HttpGet]
        public ActionResult ClassEvents(int classId)
        {
            var viewModel = new ClassEventsViewModel();
            viewModel.EventsList = _teacherManager.EventsGet_ForClass(classId);
            viewModel.Class = _teacherManager.ClassGet(classId);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult DeleteEvent(long eventId, int classId)
        {
            return View();
        }
    }
}