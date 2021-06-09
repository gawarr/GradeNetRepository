using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Core.Models
{
    public class GradeModel
    {
        public long GradeId { get; set; }
        public string Grade { get; set; }
        public string Style { get; set; }
        public int StudentId { get; set; }
        public byte Semester { get; set; }

        public GradeModel() { }

        public GradeModel(long gradeId, string grade, string style, int studentId, byte semester)
        {
            GradeId = gradeId;
            Grade = grade;
            Style = style;
            StudentId = studentId;
            Semester = semester;
        }
    }
}