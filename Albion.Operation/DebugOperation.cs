using Albion.Network;
using System.Collections.Generic;
using System;

namespace Albion.Operation
{
    public class DebugOperation : BaseOperation
    {
        public DebugOperation(Dictionary<byte, object> parameters) : base(parameters)
        {
            Parameters = parameters;
        }

        public Dictionary<byte, object> Parameters { get; }
        public void showMe()
        {
            foreach (object o in Parameters)
            {
                Console.WriteLine("OpData: " + o.ToString());
            }
        }
    }
}
