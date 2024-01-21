using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Business.CustomException.AccountException
{
    public class InvalidLoginException : Exception
    {
        public readonly string propertyname;

        public InvalidLoginException()
        {
        }

        public InvalidLoginException(string? message) : base(message)
        {
        }
        public InvalidLoginException(string propertyname,string? message) : base(message)
        {
            this.propertyname = propertyname;
        }
    }
}
