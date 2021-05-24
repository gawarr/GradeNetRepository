using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.ViewModels
{
    public class ClassViewModel
    {
        public int ClassId { get; set; }
        public string Name { get; set; }

        public ClassViewModel() { }
        public ClassViewModel(int classId, string name)
        {
            ClassId = classId;
            Name = name;
        }
    }
}
