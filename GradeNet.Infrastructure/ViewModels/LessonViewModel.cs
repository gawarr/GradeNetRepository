using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.ViewModels
{
    public class LessonViewModel
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int TeacherId { get; set; }
        public int PreviewTypeId { get; set; }
        public UserDetailsViewModel TeacherDetails { get; set; }
        public List<StudentViewModel> StudentsList { get; set; }
        public List<GradeViewModel> StudentsGradesList { get; set; }
        public List<SubjectViewModel> SubjectsList { get; set; }

        public LessonViewModel() { }

        public LessonViewModel(int lessonId, string lessonName, int classId)
        {
            LessonId = lessonId;
            LessonName = lessonName;
            ClassId = classId;
        }

        public LessonViewModel(int lessonId, string lessonName, int classId, string className, int teacherId, UserDetailsViewModel teacherDetails)
        {
            LessonId = lessonId;
            LessonName = lessonName;
            ClassId = classId;
            ClassName = className;
            TeacherId = teacherId;
            TeacherDetails = teacherDetails;
        }
    }
}
