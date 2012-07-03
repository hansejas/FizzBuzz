using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeMorph.FizzBuzz.Application
{
    /// <summary>
    /// Formats text for numeric values between Minimum and Maximum.  Will replace any input value 
    /// </summary>
    public class Formatter
    {
        Dictionary<int, string> tokenMapper;

        /// <summary>
        /// minimum value for formatter input
        /// </summary>
        public int Minimum { get; set; }

        /// <summary>
        /// maximum value for input
        /// </summary>
        public int Maximum { get; set; }

        /// <summary>
        /// mapping used by formatter
        /// </summary>
        public Dictionary<int, string> TokenMapper
        {
            //TokenMapper Property
            get 
            {
                if (tokenMapper == null)
                {
                    tokenMapper = new Dictionary<int, string>();
                }
                return tokenMapper; 
            }
            set { tokenMapper = value; }
        }

        /// <summary>
        /// Format Integer value
        /// </summary>
        /// <param name="rawNumber">integer to be formatted</param>
        /// <returns>formatted integer</returns>
        public string FormatInteger(int rawNumber)
        {
            var formattedString = String.Empty;
            this.Validate();

            return formattedString;
        }

        /// <summary>
        /// Ensure Formatter is in a valid state
        /// </summary>
        public void Validate()
        {
            if (TokenMapper.Count <= 0)
            {
                throw new InvalidTokenMapperException("TokenMapper must have mappings");
            }
            if (Minimum > Maximum)
            {
                throw new InvalidFormatterRangeException("Minimum must not be greater than maximum");
            }

        }
    }
}
