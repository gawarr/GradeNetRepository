using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.ViewModels
{
    public class EditGradeViewModel
    {
        public int LessonId { get; set; }
        public int ClassId { get; set; }
        public string LessonName { get; set; }
        public string Grade { get; set; }
        public long StudentGradeId { get; set; }
        public byte Semestr { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int TeacherId { get; set; }

        public List<GradeViewModel> GradesList { get; set; }

        public EditGradeViewModel() { }
    }
}
