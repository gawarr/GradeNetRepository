using GradeNet.Infrastructure.Helpers;
using GradeNet.Infrastructure.Interfaces;
using GradeNet.Infrastructure.ViewModels;
using NLog;
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
        private static Logger logger = LogManager.GetLogger("loggerRole");
        private readonly ITeacherManager _teacherManager;

        public TeacherController(ITeacherManager teacherManager)
        {
            _teacherManager = teacherManager;
        }

        public ActionResult FindClass()
        {
            logger.Debug($"{User.Identity.Name} - FindClass().");
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
            logger.Debug($"{User.Identity.Name} - Class(int {classId}).");
            var classVM = _teacherManager.ClassGet(classId);

            return View(classVM);
        }

        public ActionResult SelectLesson(int classId)
        {
            logger.Debug($"{User.Identity.Name} - SelectLesson(int {classId}).");
            var lessons = _teacherManager.LessonsGet_ForClass(classId);

            return View(lessons);
        }

        [HttpGet]
        public ActionResult Lesson(int lessonId, int previewTypeId = 0)
        {
            logger.Debug($"{User.Identity.Name} - Lesson(int {lessonId}, int {previewTypeId}).");
            var lessonVm = _teacherManager.GetLessonView(lessonId, previewTypeId);

            return View(lessonVm);
        }

        [HttpGet]
        public ActionResult AddGrade(int studentId, string studentName, int lessonId, int classId)
        {
            logger.Debug($"{User.Identity.Name} - AddGrade(int {studentId}, string {studentName}, int {lessonId}, int {classId}).");
            var model = new AddGradeViewModel()
            {
                StudentId = studentId,
                StudentName = studentName,

                LessonId = lessonId,
                LessonName = _teacherManager.LessonGet(lessonId).LessonName,

                ClassId = classId
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddGrade(int studentId, string studentName, int lessonId, string lessonName, string grade, int style, string semester, int classId)
        {
            logger.Debug($"{User.Identity.Name} - AddGrade(int {studentId}, string {studentName}, int {lessonId}, string {grade}, int {style}, string {semester}, int {classId}).");
            var model = new AddGradeViewModel()
            {
                StudentId = studentId,
                StudentName = studentName,

                LessonId = lessonId,
                LessonName = String.IsNullOrEmpty(lessonName) ? _teacherManager.LessonGet(lessonId).LessonName : lessonName,

                ClassId = classId
            };

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
        public ActionResult EditGrade(int studentId, string studentName, int lessonId, string lessonName, int classId)
        {
            logger.Debug($"{User.Identity.Name} - EditGrade(int {studentId}, string {studentName}, int {lessonId}, string {lessonName}, int {classId}).");

            var model = new EditGradeViewModel()
            {
                StudentId = studentId,
                StudentName = studentName,

                LessonId = lessonId,
                LessonName = String.IsNullOrEmpty(lessonName) ? _teacherManager.LessonGet(lessonId).LessonName : lessonName,

                ClassId = classId
            };

            model.GradesList = _teacherManager.StudentGradesGet(studentId, lessonId);

            return View(model);
        }

        [HttpPost]
        public ActionResult CorrectGrade(int studentId, string studentName, int lessonId, string lessonName, int classId, long studentGradeId, string correctionType = "", string grade = "", string semester = "", int styleId = 0)
        {
            logger.Debug($"{User.Identity.Name} - CorrectGrade(int {studentId}, string {studentName}, int {lessonId}, string {lessonName}, int {classId}, long {studentGradeId}, string {correctionType}, string {grade}, string {semester}, int {styleId}).");

            var model = new EditGradeViewModel()
            {
                StudentId = studentId,
                StudentName = studentName,

                LessonId = lessonId,
                LessonName = String.IsNullOrEmpty(lessonName) ? _teacherManager.LessonGet(lessonId).LessonName : lessonName,

                ClassId = classId,

                StudentGradeId = studentGradeId
            };

            string teacherEmail = User.Identity.Name;
            bool isCorrect = true;

            switch (correctionType)
            {
                case "delete":
                    isCorrect = _teacherManager.StudentGradeUpdate_Disable(studentGradeId, teacherEmail);
                    if (isCorrect)
                    {
                        ViewBag.Info = "Usunięto ocenę";
                        return View("Lesson", _teacherManager.GetLessonView(lessonId, 0));
                    }
                    else
                    {
                        ViewBag.Info = "Błąd usuwaniu oceny";
                        return View(model);
                    }

                case "edit":
                    isCorrect = _teacherManager.StudentGradeUpdate(studentGradeId, grade, semester, styleId, teacherEmail);
                    if (isCorrect)
                    {
                        ViewBag.Info = "Edytowano ocenę";
                        return View("Lesson", _teacherManager.GetLessonView(lessonId, 0));
                    }
                    else
                    {
                        ViewBag.Info = "Błąd przy edycji oceny";
                        return View(model);
                    }

                default:
                    break;
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult SelectStudentFromClass(int classId)
        {
            logger.Debug($"{User.Identity.Name} - SelectStudentFromClass(int {classId}).");
            ViewBag.ClassId = classId;
            var studentsList = _teacherManager.StudentsGet(classId);

            return View(studentsList);
        }

        [HttpGet]
        public ActionResult StudentsComments(int studentId, int classId)
        {
            logger.Debug($"{User.Identity.Name} - StudentsComments(int {studentId}, int {classId}).");
            ViewBag.ClassId = classId;
            var commentsList = _teacherManager.StudentsCommentsGet(studentId);

            return View(commentsList);
        }

        [HttpGet]
        public ActionResult EditComment(int studentId, int commentId, int classId)
        {
            logger.Debug($"{User.Identity.Name} - EditComment(int {studentId}, int {classId}).");
            ViewBag.ClassId = classId;
            //var commentsList = _teacherManager.StudentsCommentsGet(studentId);

            var commentsList = _teacherManager.StudentsCommentsGet(studentId);

            return View("StudentsComments", commentsList);
        }

        [HttpGet]
        public ActionResult DeleteComment(int studentId, int commentId, int classId)
        {
            logger.Debug($"{User.Identity.Name} - DeleteComment(int {studentId}, int {commentId}, int {classId}).");
            ViewBag.ClassId = classId;
            //var commentsList = _teacherManager.StudentsCommentsGet(studentId);

            var commentsList = _teacherManager.StudentsCommentsGet(studentId);

            return View("StudentsComments", commentsList);
        }

        [HttpGet]
        public ActionResult ClassEvents(int classId)
        {
            logger.Debug($"{User.Identity.Name} - ClassEvents(int {classId}).");
            var viewModel = new ClassEventsViewModel();
            viewModel.EventsList = _teacherManager.EventsGet_ForClass(classId);
            viewModel.Class = _teacherManager.ClassGet(classId);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult DeleteEvent(long eventId, int classId)
        {
            logger.Debug($"{User.Identity.Name} - DeleteEvent(long {eventId}, int {classId}).");
            return View();
        }
    }
}