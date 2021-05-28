using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Core.Models
{
    public class ClassModel
    {
        public int ClassId { get; set; }
        public string Name { get; set; }

        public ClassModel() { }

        public ClassModel(int classId, string name)
        {
            ClassId = classId;
            Name = name;
        }
    }
}
