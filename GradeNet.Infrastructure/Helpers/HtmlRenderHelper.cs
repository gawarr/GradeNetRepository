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

            string x = "<select onchange='GetLessonsSelect()' class='select' id='classSelect'>";
            x += $"<option value='0'> </option>";
            foreach (var cl in classList)
            {
                x += $"<option value='{cl.ClassId}'>{cl.Name}</option>";
            }
            x += "</select>";

            return x;
        }
    }
}
