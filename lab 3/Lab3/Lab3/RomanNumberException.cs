using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class RomanNumberException : Exception
    {
        public RomanNumberException(string message) : base(message) { }
        //internal RomanNumberException(string message, Exception inner) : base(message, inner) { }
    }
}
