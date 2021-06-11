using GradeNet.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.Interfaces
{
    public interface ITeacherManager
    {
        List<int> YearsGet();
        string GetHtmlForClassSelect(int year);
        List<StudentViewModel> StudentsGet(int classId);
        ClassViewModel ClassGet(int classId);
        List<LessonViewModel> LessonsGet_ForClass(int classId);
        LessonViewModel LessonGet(int lessonId);
        LessonViewModel GetLessonView(int lessonId, int previewTypeId);
        List<CommentsViewModel> StudentsCommentsGet(int studentId);
        List<EventViewModel> EventsGet_ForClass(int classId);
        bool GradeAdd(string grade, string semester, int styleId, int studentId, int lessonId, string email);
    }
}
