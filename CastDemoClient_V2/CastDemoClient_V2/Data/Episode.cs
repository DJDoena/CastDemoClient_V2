using System;
using System.Collections.Generic;

namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    internal class Episode : CastEntry
    {
        public override String FirstName
        {
            get
            {
                return (EpisodeNumber);
            }
            set
            {
                throw (new NotImplementedException());
            }
        }

        public override String MiddleName
        {
            get
            {
                return (EpisodeName);
            }
            set
            {
                throw (new NotImplementedException());
            }
        }

        public override String LastName
        {
            get
            {
                return (String.Empty);
            }
            set
            {
                throw (new NotImplementedException());
            }
        }

        public override String Role
        {
            get
            {
                return (String.Empty);
            }
            set
            {
                throw (new NotImplementedException());
            }
        }

        public override Boolean Voice
        {
            get
            {
                return (false);
            }
            set
            {
                throw (new NotImplementedException());
            }
        }


        public override String CastId
        {
            get
            {
                return (String.Empty);
            }
            set
            {
                throw (new NotImplementedException());
            }
        }

        public override String CreditedAs
        {
            get
            {
                return (String.Empty);
            }
            set
            {
                throw (new NotImplementedException());
            }
        }

        public String EpisodeNumber { get; set; }

        public String EpisodeName { get; set; }

        public List<CastMember> CastList { get; set; }
    }
}