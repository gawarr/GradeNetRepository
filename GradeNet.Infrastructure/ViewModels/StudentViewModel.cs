using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }

        public StudentViewModel() { }

        public StudentViewModel(int studentId, string firstName, string secondName, string surname)
        {
            StudentId = studentId;
            FirstName = firstName;
            SecondName = secondName;
            Surname = surname;
        }
    }
}
