using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Business.CustomException.ExploreException
{
    public class ExploreNullException : Exception
    {
        public readonly string propertyname;

        public ExploreNullException()
        {
        }

        public ExploreNullException(string? message) : base(message)
        {
        }
        public ExploreNullException(string propertyname,string? message) : base(message)
        {
            this.propertyname = propertyname;
        }
    }
}
