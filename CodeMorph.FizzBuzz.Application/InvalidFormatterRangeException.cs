using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeMorph.FizzBuzz.Application
{
    /// <summary>
    /// Formatter Range Exception
    /// </summary>
    public class InvalidFormatterRangeException : Exception
    {
        /// <summary>
        /// Creates InvalidFormatterRangeException with given message
        /// </summary>
        /// <param name="message"></param>
        public InvalidFormatterRangeException(string message)
            : base(message)
        {
        }

    }
}
