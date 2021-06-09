using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.ViewModels
{
    public class SubjectViewModel
    {
        public long SubjectId { get; set; }
        public string Subject { get; set; }
        public DateTime SubjectDate { get; set; }

        public SubjectViewModel() { }

        public SubjectViewModel(long subjectId, string subject, DateTime subjectDate)
        {
            SubjectId = subjectId;
            Subject = subject;
            SubjectDate = subjectDate;
        }
    }
}
