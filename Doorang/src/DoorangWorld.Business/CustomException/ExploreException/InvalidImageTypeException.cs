using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Business.CustomException.ExploreException
{
    public class InvalidImageTypeException : Exception
    {
        private readonly string proprtyname;

        public InvalidImageTypeException()
        {
        }

        public InvalidImageTypeException(string? message) : base(message)
        {
        }
        public InvalidImageTypeException(string proprtyname,string? message) : base(message)
        {
            this.proprtyname = proprtyname;
        }
    }
}
