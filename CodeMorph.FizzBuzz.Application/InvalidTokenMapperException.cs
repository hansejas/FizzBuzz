using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeMorph.FizzBuzz.Application
{
    /// <summary>
    /// Formatter Token Mapper Exception
    /// </summary>
    public class InvalidTokenMapperException : Exception
    {
        /// <summary>
        /// Creates InvalidTokenMapperException with given message
        /// </summary>
        /// <param name="message"></param>
        public InvalidTokenMapperException(string message)
            : base(message)
        {

        }
    }
}
