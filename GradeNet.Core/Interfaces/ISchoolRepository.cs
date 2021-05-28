using GradeNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Core.Interfaces
{
    public interface ISchoolRepository
    {
        List<int> YearsGet();
        List<ClassModel> ClassesGet_ForYear(int fromYear);
        List<StudentModel> StudentsGet(int classId);
    }
}
