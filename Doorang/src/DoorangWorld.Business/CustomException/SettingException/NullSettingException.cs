using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Business.CustomException.SettingException
{
    public class NullSettingException : Exception
    {
        public readonly string propertyNAME;

        public NullSettingException()
        {
        }

        public NullSettingException(string? message) : base(message)
        {
        }
        public NullSettingException(string propertyNAME,string? message) : base(message)
        {
            this.propertyNAME = propertyNAME;
        }
    }
}
