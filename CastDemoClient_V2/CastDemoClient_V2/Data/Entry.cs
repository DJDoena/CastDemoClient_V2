using System;

namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    internal abstract class Entry
    {
        public virtual String FirstName { get; set; }

        public virtual String MiddleName { get; set; }

        public virtual String LastName { get; set; }

        public virtual String CreditedAs { get; set; }
    }
}