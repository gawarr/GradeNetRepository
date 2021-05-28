﻿using GradeNet.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.Interfaces
{
    public interface ISchoolManager
    {
        List<int> YearsGet();
        List<StudentViewModel> StudentsGet(int classId);
    }
}
