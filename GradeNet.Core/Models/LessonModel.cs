﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Core.Models
{
    public class LessonModel
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int TeacherId { get; set; }
        public UserDetailsModel TeacherDetails { get; set; }


        public LessonModel() { }

        public LessonModel(int lessonId, string lessonName)
        {
            LessonId = lessonId;
            LessonName = lessonName;
        }

        public LessonModel(int lessonId, string lessonName, int classId, string className, int teacherId, UserDetailsModel teacherDetails)
        {
            LessonId = lessonId;
            LessonName = lessonName;
            ClassId = classId;
            ClassName = className;
            TeacherId = teacherId;
            TeacherDetails = teacherDetails;
        }
    }
}
