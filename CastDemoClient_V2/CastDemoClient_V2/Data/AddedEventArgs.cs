using System;

namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    internal class AddedEventArgs : EventArgs
    {
        public CastEntry NewCastEntry { get; private set; }

        public AddedEventArgs(CastEntry newCastEntry)
        {
            NewCastEntry = newCastEntry;
        }
    }
}