using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.ViewModels
{
    public class GradeViewModel
    {
        public long StudentGradeId { get; set; }
        public string Grade { get; set; }
        public string Style { get; set; }
        public int StudentId { get; set; }
        public byte Semester { get; set; }

        public GradeViewModel() { }

        public GradeViewModel(long studentGradeId, string grade, string style, int studentId, byte semester)
        {
            StudentGradeId = studentGradeId;
            Grade = grade;
            Style = style;
            StudentId = studentId;
            Semester = semester;
        }
    }
}
