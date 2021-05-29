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
    }
}
