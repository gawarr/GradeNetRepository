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
        LessonViewModel GetLessonView(int lessonId, int previewTypeId);
        List<CommentsViewModel> StudentsCommentsGet(int studentId);
    }
}
