using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Core.Models
{
    public class SubjectModel
    {
        public long SubjectId { get; set; }
        public string Subject { get; set; }
        public DateTime SubjectDate { get; set; }
        public SubjectModel() { }

        public SubjectModel(long subjectId, string subject, DateTime subjectDate)
        {
            SubjectId = subjectId;
            Subject = subject;
            SubjectDate = subjectDate;
        }
    }
}
