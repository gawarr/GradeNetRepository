﻿using GradeNet.Core.Enums;
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
    public class TeacherManager : ITeacherManager
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherManager()
        {
            _teacherRepository = new TeacherRepository();
        }

        public List<int> YearsGet() => _teacherRepository.YearsGet();

        public string GetHtmlForClassSelect(int year)
        {
            var classList = _teacherRepository.ClassesGet_ForYear(year);

            string html = "<select class='select' name='classId' id='classSelect'>";
            foreach (var cl in classList)
            {
                html += $"<option value='{cl.ClassId}'>{cl.Name}</option>";
            }
            html += "</select>";

            return html;
        }

        public List<StudentViewModel> StudentsGet(int classId)
        {
            var list = new List<StudentViewModel>();
            var result = _teacherRepository.StudentsGet(classId);

            if(result.Any()) 
                list.AddRange(result.Select(x => new StudentViewModel(x.StudentId, x.FirstName, x.SecondName, x.Surname)));

            return list;
        }

        public ClassViewModel ClassGet(int classId)
        {
            var result = _teacherRepository.ClassGet(classId);

            ClassViewModel classVM = new ClassViewModel(result.ClassId, result.Name, result.TeacherId, new UserDetailsViewModel(result.TeacherDetails.FirstName, result.TeacherDetails.SecondName, result.TeacherDetails.Surname));
            classVM.StudentsList = new List<StudentViewModel>();

            var list = _teacherRepository.StudentsGet(classId);
            if (list.Any())
                classVM.StudentsList.AddRange(list.Select(x => new StudentViewModel(x.StudentId, x.FirstName, x.SecondName, x.Surname)));

            return classVM;
        }

        public List<LessonViewModel> LessonsGet_ForClass(int classId)
        {
            var lessonsList = new List<LessonViewModel>();

            var list = _teacherRepository.LessonsGet_ForClass(classId);
            if (list.Any())
                lessonsList.AddRange(list.Select(x => new LessonViewModel(x.LessonId, x.LessonName)));

            return lessonsList;
        }

        public LessonViewModel GetLessonView(int lessonId, int previewTypeId)
        {
            var model = _teacherRepository.LessonsGet(lessonId);

            var lessonVM = new LessonViewModel(model.LessonId, model.LessonName, model.ClassId, model.ClassName, model.TeacherId, 
                new UserDetailsViewModel(model.TeacherDetails.FirstName, model.TeacherDetails.SecondName, model.TeacherDetails.Surname));

            var studentsList = _teacherRepository.StudentsGet(lessonVM.ClassId);

            lessonVM.StudentsList = new List<StudentViewModel>();
            if (studentsList.Any())
                lessonVM.StudentsList.AddRange(studentsList.Select(x => new StudentViewModel(x.StudentId, x.FirstName, x.SecondName, x.Surname)));

            switch ((PreviewEnum)previewTypeId)
            {
                case PreviewEnum.Oceny:
                default:
                    lessonVM.PreviewTypeId = (int)PreviewEnum.Oceny;

                    var gradesList = _teacherRepository.StudentsGradesGet_ForLesson(lessonId);

                    lessonVM.StudentsGradesList = new List<GradeViewModel>();
                    if (gradesList.Any())
                        lessonVM.StudentsGradesList.AddRange(gradesList.Select(x => new GradeViewModel(x.GradeId, x.Grade, x.Style, x.StudentId)));
                    break;
            }

            return lessonVM;
        }
    }
}
