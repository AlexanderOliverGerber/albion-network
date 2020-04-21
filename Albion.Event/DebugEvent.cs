using Albion.Network;
using System.Collections.Generic;
using System;

namespace Albion.Event
{
    public class DebugEvent : BaseEvent
    {
        public DebugEvent(Dictionary<byte, object> parameters) : base(parameters)
        {
            Parameters = parameters;
        }

        public Dictionary<byte, object> Parameters { get; }
        public void showMe()
        {
            foreach (object o in Parameters)
            {
                Console.WriteLine("EventData " + o.ToString());
            }
        }
    }
}
