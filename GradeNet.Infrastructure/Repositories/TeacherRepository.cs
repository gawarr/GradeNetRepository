using GradeNet.Core.Interfaces;
using GradeNet.Core.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private static Logger logger = LogManager.GetLogger("loggerRole");
        public List<int> YearsGet()
        {
            try
            {
                logger.Info($"Start YearsGet().");
                var list = new List<int>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.YearsGet().ToList();
                    list = result.ConvertAll(x => (int)x);
                }
                logger.Info($"Koniec YearsGet().");

                return list;
            }
            catch (Exception ex)
            {
                logger.Error($"YearsGet() - {ex}.");
                return new List<int>();
            }
        }

        public List<ClassModel> ClassesGet_ForYear(int fromYear)
        {
            try
            {
                logger.Info($"Start ClassesGet_ForYear(int {fromYear}).");
                var list = new List<ClassModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.ClassesGet_ForYear(fromYear).ToList();
                    if (result.Any())
                        list.AddRange(result.Select(x => new ClassModel(x.ClassId, x.Name)));
                }
                logger.Info($"Koniec ClassesGet_ForYear(int {fromYear}).");

                return list;
            }
            catch (Exception ex)
            {
                logger.Error($"ClassesGet_ForYear(int {fromYear}) - {ex}.");
                return new List<ClassModel>();
            }
        }

        public List<StudentModel> StudentsGet(int classId)
        {
            try
            {
                logger.Info($"Start - StudentsGet(int {classId}).");
                var list = new List<StudentModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.StudentsGet(classId).ToList();
                    if (result.Any())
                        list.AddRange(result.Select(x => new StudentModel(x.StudentId, x.FirstName, x.SecondName, x.Surname)));
                }
                logger.Info($"Koniec - StudentsGet(int {classId}).");

                return list;
            }
            catch (Exception ex)
            {
                logger.Error($"StudentsGet(int {classId}) - {ex}.");
                return new List<StudentModel>();
            }
        }

        public ClassModel ClassGet(int classId)
        {
            try
            {
                logger.Info($"Start - ClassGet(int {classId}).");
                ClassModel classM;

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.ClassGet(classId).FirstOrDefault();
                    classM = new ClassModel(result.ClassId, result.Name, result.MainTeacherId, new UserDetailsModel(result.FirstName, result.SecondName, result.Surname));
                }
                logger.Info($"Koniec - ClassGet(int {classId}).");

                return classM;
            }
            catch (Exception ex)
            {
                logger.Error($"ClassGet(int {classId}) - {ex}.");
                return new ClassModel();
            }
        }

        public List<LessonModel> LessonsGet_ForClass(int classId)
        {
            try
            {
                logger.Info($"Start - LessonsGet_ForClass(int {classId}).");
                var list = new List<LessonModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.LessonsGet_ForClass(classId).ToList();
                    if (result.Any())
                        list.AddRange(result.Select(x => new LessonModel(x.LessonId, x.Name)));
                }
                logger.Info($"Koniec - LessonsGet_ForClass(int {classId}).");

                return list;
            }
            catch (Exception ex)
            {
                logger.Error($"LessonsGet_ForClass(int {classId}) - {ex}.");
                return new List<LessonModel>();
            }
        }

        public LessonModel LessonGet(int lessonId)
        {
            try
            {
                logger.Info($"Start - LessonGet(int {lessonId}).");
                LessonModel model;

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.LessonGet(lessonId).FirstOrDefault();

                    model = new LessonModel(result.LessonId, result.LessonName, result.ClassId, result.ClassName, 
                        result.TeacherId, new UserDetailsModel(result.FirstName, result.SecondName, result.Surname));
                }
                logger.Info($"Koniec - LessonGet(int {lessonId}).");

                return model;
            }
            catch (Exception ex)
            {
                logger.Error($"LessonGet(int {lessonId}) - {ex}.");
                return new LessonModel();
            }
        }

        public List<GradeModel> StudentsGradesGet_ForLesson(int lessonId)
        {
            try
            {
                logger.Info($"Koniec - StudentsGradesGet_ForLesson(int {lessonId}).");
                var list = new List<GradeModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.StudentGradesGet_ForLesson(lessonId).ToList();
                    if (result.Any())
                        list.AddRange(result.Select(x => new GradeModel(x.StudentGradeId, x.Grade, x.Style, x.StudentId, Convert.ToByte(x.Semester))));
                }
                logger.Info($"Koniec - StudentsGradesGet_ForLesson(int {lessonId}).");

                return list;
            }
            catch (Exception ex)
            {
                logger.Error($"StudentsGradesGet_ForLesson(int {lessonId}) - {ex}.");
                return new List<GradeModel>();
            }
        }

        public List<GradeModel> StudentGradesGet(int studentId, int lessonId)
        {
            try
            {
                logger.Info($"Start - StudentGradesGet(int {studentId}, int {lessonId}).");
                var list = new List<GradeModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.StudentGradesGet(lessonId, studentId).ToList();
                    if (result.Any())
                        list.AddRange(result.Select(x => new GradeModel(x.StudentGradeId, x.Grade, x.Style, x.StudentId, Convert.ToByte(x.Semester))));
                }
                logger.Info($"Koniec - StudentGradesGet(int {studentId}, int {lessonId}).");

                return list;
            }
            catch (Exception ex)
            {
                logger.Error($"StudentGradesGet(int {studentId}, int {lessonId}) - {ex}.");
                return new List<GradeModel>();
            }
        }

        public List<SubjectModel> SubjectsGet(int lessonId)
        {
            try
            {
                logger.Info($"Start - SubjectsGet(int {lessonId}).");
                var list = new List<SubjectModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.SubjectsGet(lessonId).ToList();
                    if (result.Any())
                        list.AddRange(result.Select(x => new SubjectModel(x.SubjectId, x.Subject, x.SubjectDate)));
                }
                logger.Info($"Koniec - SubjectsGet(int {lessonId}).");

                return list;
            }
            catch (Exception ex)
            {
                logger.Error($"SubjectsGet(int {lessonId}) - {ex}.");
                return new List<SubjectModel>();
            }
        }

        public List<CommentsModel> StudentsCommentsGet(int studentId)
        {
            logger.Info($"Start - StudentsCommentsGet(int {studentId}).");
            try
            {
                var list = new List<CommentsModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.StudentsCommentsGet(studentId).ToList();
                    if (result.Any())
                        list.AddRange(result.Select(x => new CommentsModel(x.CommentId, x.Content, new StudentModel(studentId, x.StudentFirstName, x.StudentSecondName, x.StudentSurname), x.TeacherFirstName, x.TeacherSecondName, x.TeacherSurname, x.CreationTime)));
                }
                logger.Info($"Koniec - StudentsCommentsGet(int {studentId}).");

                return list;
            }
            catch (Exception ex)
            {
                logger.Error($"StudentsCommentsGet(int {studentId}) - {ex}.");
                return new List<CommentsModel>();
            }
        }

        public List<EventModel> EventsGet_ForClass(int classId)
        {
            try
            {
                logger.Info($"Start - EventsGet_ForClass(int {classId}).");
                var list = new List<EventModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.EventsGet_ForClass(classId).ToList();
                    if (result.Any())
                        list.AddRange(result.Select(x => new EventModel(x.EventId, x.EventType, x.Shortcut, x.EventDate, x.Description)));
                }
                logger.Info($"Koniec - EventsGet_ForClass(int {classId}).");

                return list;
            }
            catch (Exception ex)
            {
                logger.Error($"EventsGet_ForClass(int {classId}) - {ex}.");
                return new List<EventModel>();
            }
        }

        public bool GradeAdd(string grade, int semester, int styleId, int studentId, int lessonId, string email)
        {
            try
            {
                logger.Info($"Koniec - GradeAdd().");
                using (var context = new GradeNet_Entities())
                {
                    context.StudentGradeAdd(grade, Convert.ToBoolean(semester), Convert.ToByte(styleId), studentId, lessonId, email);
                }
                logger.Info($"Koniec - GradeAdd().");

                return true;
            }
            catch (Exception ex)
            {
                logger.Error($"GradeAdd() - {ex}.");
                return false;
            }
        }

        public bool StudentGradeUpdate(long studentGradeId, string grade, int semester, int styleId, string email)
        {
            try
            {
                logger.Info($"Koniec - StudentGradeUpdate().");
                using (var context = new GradeNet_Entities())
                {
                    context.StudentGradeUpdate(studentGradeId, grade, Convert.ToBoolean(semester), Convert.ToByte(styleId), email);
                }
                logger.Info($"Koniec - StudentGradeUpdate().");

                return true;
            }
            catch (Exception ex)
            {
                logger.Error($"StudentGradeUpdate() - {ex}.");
                return false;
            }
        }

        public bool StudentGradeUpdate_Disable(long studentGradeId, string email)
        {
            try
            {
                logger.Info($"Koniec - StudentGradeUpdate_Disable().");
                using (var context = new GradeNet_Entities())
                {
                    context.StudentGradeUpdate_Disable(studentGradeId, email);
                }
                logger.Info($"Koniec - StudentGradeUpdate_Disable().");

                return true;
            }
            catch (Exception ex)
            {
                logger.Error($"StudentGradeUpdate_Disable() - {ex}.");
                return false;
            }
        }
    }
}
