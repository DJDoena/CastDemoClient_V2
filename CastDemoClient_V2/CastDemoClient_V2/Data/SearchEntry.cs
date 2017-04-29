using System;
using System.Collections.Generic;

namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    internal abstract class SearchEntry : Entry
    {
        public virtual String Title { get; set; }

        public virtual String ProductionYear { get; set; }

        public List<SearchResult> ResultList { get; set; }
    }
}