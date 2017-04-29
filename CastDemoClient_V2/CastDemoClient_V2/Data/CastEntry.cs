using System;

namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    internal abstract class CastEntry : Entry
    {
        public virtual String Role { get; set; }

        public virtual Boolean Voice { get; set; }

        public virtual String CastId { get; set; }

        public String Upc { get; set; }
    }
}