using GradeNet.Core.Enums;
using GradeNet.Core.Interfaces;
using GradeNet.Core.Models;
using GradeNet.Infrastructure.Helpers;
using GradeNet.Infrastructure.Interfaces;
using GradeNet.Infrastructure.Repositories;
using GradeNet.Infrastructure.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.Managers
{
    public class TeacherManager : ITeacherManager
    {
        private static Logger logger = LogManager.GetLogger("loggerRole");
        private readonly ITeacherRepository _teacherRepository;

        public TeacherManager()
        {
            _teacherRepository = new TeacherRepository();
        }

        public List<int> YearsGet() => _teacherRepository.YearsGet();

        public string GetHtmlForClassSelect(int year)
        {
            var classList = _teacherRepository.ClassesGet_ForYear(year);

            string html = "<select class='select' name='classId' id='classSelect'>";
            foreach (var cl in classList)
            {
                html += $"<option value='{cl.ClassId}'>{cl.Name}</option>";
            }
            html += "</select>";

            return html;
        }

        public List<StudentViewModel> StudentsGet(int classId)
        {
            var list = new List<StudentViewModel>();
            var result = _teacherRepository.StudentsGet(classId);
            logger.Info($"StudentsGet(int {classId}) - Pobrano {result.Count()} uczniów dla klasy.");

            if (result.Any())
                list.AddRange(result.Select(x => new StudentViewModel(x.StudentId, x.FirstName, x.SecondName, x.Surname)));

            return list;
        }

        public ClassViewModel ClassGet(int classId)
        {
            var result = _teacherRepository.ClassGet(classId);

            ClassViewModel classVM = new ClassViewModel(result.ClassId, result.Name, result.TeacherId, new UserDetailsViewModel(result.TeacherDetails.FirstName, result.TeacherDetails.SecondName, result.TeacherDetails.Surname));
            classVM.StudentsList = new List<StudentViewModel>();

            var list = _teacherRepository.StudentsGet(classId);
            logger.Info($"ClassGet(int {classId}) - Pobrano {list.Count()} uczniów dla klasy.");

            if (list.Any())
                classVM.StudentsList.AddRange(list.Select(x => new StudentViewModel(x.StudentId, x.FirstName, x.SecondName, x.Surname)));

            return classVM;
        }

        public List<LessonViewModel> LessonsGet_ForClass(int classId)
        {
            var lessonsList = new List<LessonViewModel>();

            var list = _teacherRepository.LessonsGet_ForClass(classId);
            logger.Info($"LessonsGet_ForClass(int {classId}) - Pobrano {list.Count()} lekcji dla klasy.");
            if (list.Any())
                lessonsList.AddRange(list.Select(x => new LessonViewModel(x.LessonId, x.LessonName, classId)));

            return lessonsList;
        }

        public LessonViewModel LessonGet(int lessonId)
        {
            var model = _teacherRepository.LessonGet(lessonId);
            var lessons = new LessonViewModel(model.LessonId, model.LessonName, model.ClassId, model.ClassName, model.TeacherId,
                new UserDetailsViewModel(model.TeacherDetails.FirstName, model.TeacherDetails.SecondName, model.TeacherDetails.Surname));

            return lessons;
        }

        public LessonViewModel GetLessonView(int lessonId, int previewTypeId)
        {
            var model = _teacherRepository.LessonGet(lessonId);

            var lessonVM = new LessonViewModel(model.LessonId, model.LessonName, model.ClassId, model.ClassName, model.TeacherId,
                new UserDetailsViewModel(model.TeacherDetails.FirstName, model.TeacherDetails.SecondName, model.TeacherDetails.Surname));

            lessonVM.PreviewTypeId = previewTypeId;

            switch ((PreviewEnum)previewTypeId)
            {
                case PreviewEnum.Tematy:
                    var subjectsList = _teacherRepository.SubjectsGet(lessonId);

                    lessonVM.SubjectsList = new List<SubjectViewModel>();
                    logger.Info($"GetLessonView(int {lessonId}, int {previewTypeId})) - Pobrano {lessonVM.SubjectsList.Count()} tematów dla lekcji.");

                    if (subjectsList.Any())
                        lessonVM.SubjectsList.AddRange(subjectsList.Select(x => new SubjectViewModel(x.SubjectId, x.Subject, x.SubjectDate)));
                    break;

                case PreviewEnum.Oceny:
                default:
                    var studentsList = _teacherRepository.StudentsGet(lessonVM.ClassId);

                    lessonVM.StudentsList = new List<StudentViewModel>();
                    logger.Info($"GetLessonView(int {lessonId}, int {previewTypeId})) - Pobrano {lessonVM.StudentsList.Count()} studentów dla lekcji.");

                    if (studentsList.Any())
                        lessonVM.StudentsList.AddRange(studentsList.Select(x => new StudentViewModel(x.StudentId, x.FirstName, x.SecondName, x.Surname)));

                    var gradesList = _teacherRepository.StudentsGradesGet_ForLesson(lessonId);

                    lessonVM.StudentsGradesList = new List<GradeViewModel>();
                    logger.Info($"GetLessonView(int {lessonId}, int {previewTypeId})) - Pobrano {lessonVM.StudentsGradesList.Count()} ocen dla studentów.");

                    if (gradesList.Any())
                        lessonVM.StudentsGradesList.AddRange(gradesList.Select(x => new GradeViewModel(x.StudentGradeId, x.Grade, x.Style, x.StudentId, ++x.Semester)));
                    break;
            }

            return lessonVM;
        }

        public List<CommentsViewModel> StudentsCommentsGet(int studentId)
        {
            var commentsList = new List<CommentsViewModel>();

            var list = _teacherRepository.StudentsCommentsGet(studentId);
            logger.Info($"StudentsCommentsGet(int {studentId})) - Pobrano {list.Count()} uwagi dla studenta.");

            if (list.Any())
                commentsList.AddRange(list.Select(x => new CommentsViewModel(x.CommentId, x.Content, new StudentViewModel(studentId, x.Student.FirstName, x.Student.SecondName, x.Student.Surname), x.TeacherFirstName, x.TeacherSecondName, x.TeacherSurname, x.CreationTime)));

            return commentsList;
        }

        public List<EventViewModel> EventsGet_ForClass(int classId)
        {
            var eventsList = new List<EventViewModel>();

            var list = _teacherRepository.EventsGet_ForClass(classId);
            logger.Info($"EventsGet_ForClass(int {classId})) - Pobrano {list.Count()} zadarzeń dla klasy.");

            if (list.Any())
                eventsList.AddRange(list.Select(x => new EventViewModel(x.EventId, x.EventType, x.Shortcut, x.EventDate, x.Description)));

            return eventsList;
        }

        public bool GradeAdd(string grade, string semester, int styleId, int studentId, int lessonId, string email)
        {
            bool isCorrect = GradeValidation(grade, semester, out int sem);

            if (isCorrect)
                return _teacherRepository.GradeAdd(grade, sem, Convert.ToInt32(styleId), studentId, lessonId, email);

            return false;
        }

        public bool StudentGradeUpdate(long studentGradeId, string grade, string semester, int styleId, string email)
        {
            bool isCorrect = GradeValidation(grade, semester, out int sem);

            if (isCorrect)
                return _teacherRepository.StudentGradeUpdate(studentGradeId, grade, sem, styleId, email);

            return false;
        }

        public bool StudentGradeUpdate_Disable(long studentGradeId, string email)
        {
            return _teacherRepository.StudentGradeUpdate_Disable(studentGradeId, email);
        }

        private bool GradeValidation(string grade, string semester, out int sem)
        {
            char[] s = { '1', '2' };
            sem = 0;

            if (semester.Length != 1)
                return false;

            if (!s.Contains(semester[0]))
                return false;

            sem = Convert.ToInt32(semester) - 1;

            char[] p1 = { '1', '2', '3', '4', '5', '6', '-', '+' };
            char[] p2 = { '+', '-', '=' };

            if (grade.Length < 1 || grade.Length > 2)
                return false;

            if (!p1.Contains(grade[0]))
                return false;

            if (grade.Length == 2)
            {
                if (!p2.Contains(grade[1]))
                    return false;

                if ((grade[0] == '6' && grade[1] == '+') || (grade[0] == '1' && (grade[1] == '-' || grade[1] == '=')))
                    return false;
            }

            return true;
        }

        public List<GradeViewModel> StudentGradesGet(int studentId, int lessonId)
        {
            var gradesList = new List<GradeViewModel>();

            var list = _teacherRepository.StudentGradesGet(studentId, lessonId);
            logger.Info($"StudentGradesGet(int {studentId}, int {lessonId})) - Pobrano {list.Count()}ocen dla ucznia.");

            if (list.Any())
                gradesList.AddRange(list.Select(x => new GradeViewModel(x.StudentGradeId, x.Grade, x.Style, x.StudentId, ++x.Semester)));

            return gradesList;
        }
    }
}
