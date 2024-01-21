using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Business.CustomException.ExploreException
{
    public class InvalidImageSizeException : Exception
    {
        public readonly string proprtyname;

        public InvalidImageSizeException()
        {
        }

        public InvalidImageSizeException(string? message) : base(message)
        {
        }
        public InvalidImageSizeException(string proprtyname,string? message) : base(message)
        {
            this.proprtyname = proprtyname;
        }
    }
}
