using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.ViewModels
{
    public class CommentsViewModel
    {
        public long CommentId            { get; set; }
        public string Content            { get; set; }
        public StudentViewModel Student  { get; set; }
        public string TeacherFirstName   { get; set; }
        public string TeacherSecondName  { get; set; }
        public string TeacherSurname     { get; set; }
        public DateTime CreationTime     { get; set; }

        public CommentsViewModel() { }

        public CommentsViewModel(long commentId, string content, StudentViewModel student, string tFirstName, string tSecondName, string tSurname, DateTime creationTime)
        {
            CommentId = commentId;
            Content = content;
            Student = student;
            TeacherFirstName = tFirstName;
            TeacherSecondName = tSecondName;
            TeacherSurname = tSurname;
            CreationTime = creationTime;
        }
    }
}
