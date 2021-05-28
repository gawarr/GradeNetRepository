using GradeNet.Core.Interfaces;
using GradeNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        public List<int> YearsGet()
        {
            try
            {
                var list = new List<int>();

                using(GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.YearsGet().ToList();
                    list = result.ConvertAll(x => (int)x);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ClassModel> ClassesGet_ForYear(int fromYear)
        {
            try
            {
                var list = new List<ClassModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.ClassesGet_ForYear(fromYear).ToList();
                    if(result.Any())
                        list.AddRange(result.Select(x => new ClassModel(x.ClassId, x.Name)));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<StudentModel> StudentsGet(int classId)
        {
            try
            {
                var list = new List<StudentModel>();

                using (GradeNet_Entities context = new GradeNet_Entities())
                {
                    var result = context.StudentsGet(classId).ToList();
                    if (result.Any())
                        list.AddRange(result.Select(x => new StudentModel(x.StudentId, x.FirstName, x.SecondName, x.Surname)));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
