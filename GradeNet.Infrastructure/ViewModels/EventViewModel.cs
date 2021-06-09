using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeNet.Infrastructure.ViewModels
{
    public class EventViewModel
    {
        public long EventId { get; set; }
        public string EventType { get; set; }
        public string Shortcut { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }

        public EventViewModel() { }

        public EventViewModel(long eventId, string eventType, string shortcut, DateTime eventDate, string description)
        {
            EventId = eventId;
            EventType = eventType;
            Shortcut = shortcut;
            EventDate = eventDate;
            Description = description;
        }
    }
}
