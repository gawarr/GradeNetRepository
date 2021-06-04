using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.Interfaces
{
    public interface IHtmlRenderHelper
    {
        string HtmlForClassSelectGet(int fromYear);
        string HtmlForStudentsListGet(int classId);
        string HtmlForLessonSelectGet(int classId);
        string HtmlForPreviewSelectGet(bool lessonIsChosen);
        string HtmlForPreviewGet(int classId, int lessonId, int previewType);
        string GradePreviewGet(int classId, int lessonId);
    }
}
