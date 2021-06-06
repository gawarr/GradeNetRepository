﻿using GradeNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Core.Interfaces
{
    public interface ITeacherRepository
    {
        List<int> YearsGet();
        List<ClassModel> ClassesGet_ForYear(int fromYear);
        ClassModel ClassGet(int classId);
        List<StudentModel> StudentsGet(int classId);
        List<LessonModel> LessonsGet_ForClass(int classId);
        LessonModel LessonsGet(int lessonId);
        List<GradeModel> StudentsGradesGet_ForLesson(int lessonId);
    }
}
