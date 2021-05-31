﻿using GradeNet.Core.Interfaces;
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

            string content = "<select onchange='GetStudentsList(); GetLessonsSelect();' class='select' id='classSelect'>";
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

            string content = "<select onchange='alert(`zmiana lecki`)' class='select' id='lessonSelect'>";
            content += $"<option value='0'> </option>";
            foreach (var ls in lessonsList)
            {
                content += $"<option value='{ls.LessonId}'>{ls.Name}</option>";
            }
            content += "</select>";

            return content;
        }
    }
}
