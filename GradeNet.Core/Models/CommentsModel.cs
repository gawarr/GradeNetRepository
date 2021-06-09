using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Core.Models
{
    public class CommentsModel
    {
        public long CommentId { get; set; }
        public string Content { get; set; }
        public StudentModel Student { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherSecondName { get; set; }
        public string TeacherSurname { get; set; }
        public DateTime CreationTime { get; set; }

        public CommentsModel() { }

        public CommentsModel(long commentId, string content, StudentModel student, string tFirstName, string tSecondName, string tSurname, DateTime creationTime)
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
