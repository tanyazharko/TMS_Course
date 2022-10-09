using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class AccessLevelAttribute : Attribute
    {
        public AccesLevelType type;
        public AccessLevelAttribute(AccesLevelType type)
        {
            this.type = type;
        }
    }
}
