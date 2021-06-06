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
        public int TeacherId { get; set; }
        public UserDetailsViewModel TeacherDetails { get; set; }
        public List<StudentViewModel> StudentsList { get; set; }

        public ClassViewModel() { }
        public ClassViewModel(int classId, string name, int teacherId, UserDetailsViewModel teacherDetails)
        {
            ClassId = classId;
            Name = name;
            TeacherId = teacherId;
            TeacherDetails = teacherDetails;
        }
    }
}
