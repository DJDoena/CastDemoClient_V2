using System;
using System.Text;

namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    internal class CastMember : CastEntry
    {
        public Int32 DatabaseCastId { get; set; }

        public String GetFullName()
        {
            StringBuilder sb = new StringBuilder(FirstName);

            if (String.IsNullOrEmpty(MiddleName) == false)
            {
                sb.Append(" ");
                sb.Append(MiddleName);
            }

            if (String.IsNullOrEmpty(LastName) == false)
            {
                sb.Append(" ");
                sb.Append(LastName);
            }

            return (sb.ToString());
        }
    }
}