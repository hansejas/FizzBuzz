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
        /// minimum value for range of integers to be formatted
        /// </summary>
        public int Minimum { get; set; }

        /// <summary>
        /// maximum value for range of integers to be formatted
        /// </summary>
        public int Maximum { get; set; }

        /// <summary>
        /// Maintains mappings of integers with corresponding string values to be replaced upond call to FormatInteger - used to support Business Rule #99333
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
        /// Format and append to result all integers between Minimum and Maximum
        /// </summary>
        /// <returns>appended and formatted integer values between Minimum and Maximum</returns>
        public string FormatFullRange()
        {
            var formattedNumbers = new StringBuilder();
            this.ValidateRange();

            for (int i = this.Minimum; i < this.Maximum + 1; i++)
            {
                formattedNumbers.Append(this.FormatInteger(i));
            }

            return formattedNumbers.ToString();
        }

        /// <summary>
        /// Format Integer value
        /// </summary>
        /// <param name="rawNumber">integer to be formatted</param>
        /// <returns>formatted integer</returns>
        public string FormatInteger(int rawNumber)
        {
            var formattedRawNumber = new StringBuilder();
            this.ValidateTokenMapper();
            
            // zero cannot be divided. ignore the mapping for zero
            if (rawNumber != 0)
            {
                //check tokenmapper to see if we need to substitute the the rawNumber value
                foreach (var mapping in tokenMapper)
                {
                    //Determine if our rawNumber is divisible by the key value of our tokenMapper - Business Rule #99333
                    if (rawNumber % mapping.Key == 0)
                    {
                        // append mapped value if rawNumber is divisible by the mapping key
                        formattedRawNumber.Append(mapping.Value);
                    }
                }
            }

            // if the formattedRawNumber has not had any tokenMapper values added, we must return the string representation of the integer - Business Rule #99334
            if (formattedRawNumber.Length == 0)
            {
                formattedRawNumber.Append(rawNumber.ToString());
            }
            return formattedRawNumber.ToString();
        }

        /// <summary>
        /// Ensure Formatter is in a valid state
        /// </summary>
        public void ValidateAll()
        {
            this.ValidateTokenMapper();
            this.ValidateRange();
        }

        /// <summary>
        /// Ensure TokenMapper is valid
        /// </summary>
        public void ValidateTokenMapper()
        {
            if (TokenMapper.Count <= 0)
            {
                throw new InvalidTokenMapperException("TokenMapper must have mappings");
            }
        }

        /// <summary>
        /// Ensure Minimum and Maximum are correct
        /// </summary>
        public void ValidateRange()
        {
            if (Minimum > Maximum)
            {
                throw new InvalidFormatterRangeException("Minimum must not be greater than maximum");
            }
        }

    }
}
