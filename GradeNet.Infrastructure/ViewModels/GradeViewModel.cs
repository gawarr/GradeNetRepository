using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.ViewModels
{
    public class GradeViewModel
    {
        public long GradeId { get; set; }
        public string Grade { get; set; }
        public string Style { get; set; }
        public int StudentId { get; set; }

        public GradeViewModel() { }

        public GradeViewModel(long gradeId, string grade, string style, int studentId)
        {
            GradeId = gradeId;
            Grade = grade;
            Style = style;
            StudentId = studentId;
        }
    }
}
