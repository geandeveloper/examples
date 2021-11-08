using System;
using System.Collections.Generic;

namespace DependencyInjection.Library.Common
{
    public class RequestTracker
    {
        public IList<string> Events { get; }

        public RequestTracker()
        {
            Events = new List<string>();
        }

        public RequestTracker Track(Func<string> getMessage)
        {
            Events.Add(getMessage());
            return this;
        }
    }
}