using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.ViewModels
{
    public class AddGradeViewModel
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string Grade { get; set; }
        public byte Semestr { get; set; }
        public StudentViewModel Student { get; set; }
        public int TeacherId { get; set; }

        public AddGradeViewModel() { }
    }
}
