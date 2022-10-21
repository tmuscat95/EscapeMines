using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Exceptions
{
    internal class ConfigException : Exception
    {
        public ConfigException(string message): base(message)
        {

        }

        public ConfigException(int line) : base($"Failed To Parse Config File (Line {line})")
        {

        }
    }
}
