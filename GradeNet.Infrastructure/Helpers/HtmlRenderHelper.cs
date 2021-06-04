using GradeNet.Core.Enums;
using GradeNet.Core.Interfaces;
using GradeNet.Infrastructure.Interfaces;
using GradeNet.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.Helpers
{
    public class HtmlRenderHelper : IHtmlRenderHelper
    {
        private readonly ISchoolRepository _schoolRepository;

        public HtmlRenderHelper()
        {
            _schoolRepository = new SchoolRepository();
        }

        public string HtmlForClassSelectGet(int fromYear)
        {
            var classList = _schoolRepository.ClassesGet_ForYear(fromYear);

            string content = "<select onchange='GetStudentsList(); GetLessonSelect(); GetPreviewSelect(false);' class='select' id='classSelect'>";
            content += $"<option value='0'> </option>";
            foreach (var cl in classList)
            {
                content += $"<option value='{cl.ClassId}'>{cl.Name}</option>";
            }
            content += "</select>";

            return content;
        }

        public string HtmlForStudentsListGet(int classId)
        {
            var students = _schoolRepository.StudentsGet(classId);

            string content = "<ol>";
            foreach (var st in students)
            {
                string name = String.IsNullOrEmpty(st.SecondName) ? $"{st.Surname} {st.FirstName}" : $"{st.Surname} {st.FirstName} {st.SecondName}";
                content += $"<li>{name}</li>";
            }
            content += "</ol>";

            return content;
        }

        public string HtmlForLessonSelectGet(int classId)
        {
            var lessonsList = _schoolRepository.LessonsGet_ForClass(classId);

            string content = "<select onchange='GetPreviewSelect(true);' class='select' id='lessonSelect'>";
            content += $"<option value='0'> </option>";
            foreach (var ls in lessonsList)
            {
                content += $"<option value='{ls.LessonId}'>{ls.Name}</option>";
            }
            content += "</select>";

            return content;
        }

        public string HtmlForPreviewSelectGet(bool lessonIsChosen)
        {
            if (!lessonIsChosen)
            {
                PreviewEnum[] previewList = { (PreviewEnum)4, (PreviewEnum)5 };

                string content = "<select onchange='GetPreview();' class='select' id='previewSelect'>" +
                                "   <option value='0'> </option>" +
                                $"   <option value='4'>{(PreviewEnum)4}</option>" +
                                $"   <option value='5'>{(PreviewEnum)5}</option>" +
                                "</select>";
                return content;
            }
            else
            {
                PreviewEnum[] previewList = { (PreviewEnum)1, (PreviewEnum)2, (PreviewEnum)3, (PreviewEnum)4, (PreviewEnum)5 };

                string content = "<select onchange='GetPreview();' class='select' id='previewSelect'>";
                content += $"<option value='0'> </option>";
                for (int i = 1; i <= previewList.Length; i++)
                {
                    content += $"<option value='{i}'>{previewList[i - 1]}</option>";
                }
                content += "</select>";

                return content;
            }
        }

        public string HtmlForPreviewGet(int classId, int lessonId, int previewType)
        {
            string context = "<div class='row'>";

            switch ((PreviewEnum)previewType)
            {
                case PreviewEnum.Oceny:
                    context += GradePreviewGet(classId, lessonId);
                        break;
            }

            context += "</div>";

            return context;
        }

        public string GradePreviewGet(int classId, int lessonId)
        {
            string context = "<div class='col-md-1'>" +
                             "<ul>";

            var students = _schoolRepository.StudentsGet(classId);
            foreach(var sttudent in students)
            {
                context += $"<li><button type='button' onclick='alert(`klik + {sttudent.StudentId}`)'>Szczegóły</button>    </li>";
            }

            context += "</ul>" +
                       "</div>";

            return context;
        }
    }
}
