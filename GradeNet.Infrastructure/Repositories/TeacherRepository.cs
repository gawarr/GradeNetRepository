using GradeNet.Core.Interfaces;
using GradeNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public List<int> YearsGet()
        {
            try
            {
                var list = new List<int>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.YearsGet().ToList();
                    list = result.ConvertAll(x => (int)x);
                }

                return list;
            }
            catch (Exception ex)
            {
                return new List<int>();
            }
        }

        public List<ClassModel> ClassesGet_ForYear(int fromYear)
        {
            try
            {
                var list = new List<ClassModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.ClassesGet_ForYear(fromYear).ToList();
                    if (result.Any())
                        list.AddRange(result.Select(x => new ClassModel(x.ClassId, x.Name)));
                }

                return list;
            }
            catch (Exception ex)
            {
                return new List<ClassModel>();
            }
        }

        public List<StudentModel> StudentsGet(int classId)
        {
            try
            {
                var list = new List<StudentModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.StudentsGet(classId).ToList();
                    if (result.Any())
                        list.AddRange(result.Select(x => new StudentModel(x.StudentId, x.FirstName, x.SecondName, x.Surname)));
                }

                return list;
            }
            catch (Exception ex)
            {
                return new List<StudentModel>();
            }
        }

        public ClassModel ClassGet(int classId)
        {
            try
            {
                ClassModel classM;

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.ClassGet(classId).FirstOrDefault();
                    classM = new ClassModel(result.ClassId, result.Name, result.MainTeacherId, new UserDetailsModel(result.FirstName, result.SecondName, result.Surname));
                }

                return classM;
            }
            catch (Exception ex)
            {
                return new ClassModel();
            }
        }

        public List<LessonModel> LessonsGet_ForClass(int classId)
        {
            try
            {
                var list = new List<LessonModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.LessonsGet_ForClass(classId).ToList();
                    if (result.Any())
                        list.AddRange(result.Select(x => new LessonModel(x.LessonId, x.Name)));
                }

                return list;
            }
            catch (Exception ex)
            {
                return new List<LessonModel>();
            }
        }

        public LessonModel LessonsGet(int lessonId)
        {
            try
            {
                LessonModel model;

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.LessonGet(lessonId).FirstOrDefault();

                    model = new LessonModel(result.LessonId, result.LessonName, result.ClassId, result.ClassName, 
                        result.TeacherId, new UserDetailsModel(result.FirstName, result.SecondName, result.Surname));
                }

                return model;
            }
            catch (Exception ex)
            {
                return new LessonModel();
            }
        }

        public List<GradeModel> StudentsGradesGet_ForLesson(int lessonId)
        {
            try
            {
                var list = new List<GradeModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.StudentGradesGet_ForLesson(lessonId).ToList();
                    if (result.Any())
                        list.AddRange(result.Select(x => new GradeModel(x.StudentGradeId, x.Grade, x.Style, x.StudentId, Convert.ToByte(x.Semester))));
                }

                return list;
            }
            catch (Exception ex)
            {
                return new List<GradeModel>();
            }
        }

        public List<SubjectModel> SubjectsGet(int lessonId)
        {
            try
            {
                var list = new List<SubjectModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.SubjectsGet(lessonId).ToList();
                    if (result.Any())
                        list.AddRange(result.Select(x => new SubjectModel(x.SubjectId, x.Subject, x.SubjectDate)));
                }

                return list;
            }
            catch (Exception ex)
            {
                return new List<SubjectModel>();
            }
        }

        public List<CommentsModel> StudentsCommentsGet(int studentId)
        {
            try
            {
                var list = new List<CommentsModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.StudentsCommentsGet(studentId).ToList();
                    if (result.Any())
                        list.AddRange(result.Select(x => new CommentsModel(x.CommentId, x.Content, new StudentModel(studentId, x.StudentFirstName, x.StudentSecondName, x.StudentSurname), x.TeacherFirstName, x.TeacherSecondName, x.TeacherSurname, x.CreationTime)));
                }

                return list;
            }
            catch (Exception ex)
            {
                return new List<CommentsModel>();
            }
        }
    }
}
