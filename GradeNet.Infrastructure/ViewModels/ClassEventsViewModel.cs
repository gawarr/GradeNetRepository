using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.ViewModels
{
    public class ClassEventsViewModel
    {
        public ClassViewModel Class { get; set; }
        public List<EventViewModel> EventsList { get; set; }

    }
}
