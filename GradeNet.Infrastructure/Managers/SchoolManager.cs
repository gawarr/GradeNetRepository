using GradeNet.Core.Interfaces;
using GradeNet.Core.Models;
using GradeNet.Infrastructure.Helpers;
using GradeNet.Infrastructure.Interfaces;
using GradeNet.Infrastructure.Repositories;
using GradeNet.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.Managers
{
    public class SchoolManager : ISchoolManager
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolManager()
        {
            _schoolRepository = new SchoolRepository();
        }

        public List<int> YearsGet() => _schoolRepository.YearsGet();

        public List<StudentViewModel> StudentsGet(int classId)
        {
            try
            {
                var list = new List<StudentViewModel>();
                var result = _schoolRepository.StudentsGet(classId);

                list.AddRange(result.Select(x => new StudentViewModel(x.StudentId, x.FirstName, x.SecondName, x.Surname)));

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
