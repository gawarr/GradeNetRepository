using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Core.Models
{
    public class LessonModel
    {
        public int LessonId { get; set; }
        public string Name { get; set; }

        public LessonModel() { }

        public LessonModel(int lessonId, string name)
        {
            LessonId = lessonId;
            Name = name;
        }
    }
}
