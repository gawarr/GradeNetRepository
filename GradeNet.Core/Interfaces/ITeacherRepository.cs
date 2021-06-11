using GradeNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Core.Interfaces
{
    public interface ITeacherRepository
    {
        List<int> YearsGet();
        List<ClassModel> ClassesGet_ForYear(int fromYear);
        ClassModel ClassGet(int classId);
        List<StudentModel> StudentsGet(int classId);
        List<LessonModel> LessonsGet_ForClass(int classId);
        LessonModel LessonGet(int lessonId);
        List<GradeModel> StudentsGradesGet_ForLesson(int lessonId);
        List<SubjectModel> SubjectsGet(int lessonId);
        List<CommentsModel> StudentsCommentsGet(int studentId);
        List<EventModel> EventsGet_ForClass(int classId);
        bool GradeAdd(string grade, int semester, int styleId, int studentId, int lessonId, string email);
    }
}
