using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wahh.Events
{
    class EventManager
    {
        static Queue<Event> events = new Queue<Event>();

        public static void AddEvent(Event e) 
        {
            events.Enqueue(e);
        }

        public static Event GetEvent()
        {
            return events.Dequeue();
        }

        public static void Clear()
        {
            events.Clear();
        }

        public static int Count { get { return events.Count; } }
        public static bool Empty { get { return events.Count == 0; } }
    }
}
