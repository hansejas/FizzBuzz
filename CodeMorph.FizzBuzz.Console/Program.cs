using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using CodeMorph.FizzBuzz.Application;

namespace CodeMorph.FizzBuzz.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int minimumInputValue = Convert.ToInt32(ConfigurationManager.AppSettings["FormatterMin"]);
                int maximumOutputValue = Convert.ToInt32(ConfigurationManager.AppSettings["FormatterMax"]);
                
                //Create token variable to hold the key / value pairs from app.config file
                var tokenMapper = Program.GetTokenMapper();

                //Create Formatter
                var fizzBuzzer = new Formatter();
                //Set appropriate property values 
                fizzBuzzer.Minimum = minimumInputValue;
                fizzBuzzer.Maximum = maximumOutputValue;
                fizzBuzzer.TokenMapper = tokenMapper;
                //Process - Perform FizzBuzz

                string formattedFullRange = fizzBuzzer.FormatFullRange();
                
                // should probably theck the Appsettings to ensure it is valid and throw the appropriate error. maybe refactor to call a method like we do for tokenMapper.  Am being lazy.
                var output = ConfigurationManager.AppSettings["Output"].ToString() == Enumerations.OutputSelection.Console.ToString() ? Enumerations.OutputSelection.Console : Enumerations.OutputSelection.Window;
                switch (output)
                {
                    case Enumerations.OutputSelection.Console:
                        Console.Write(formattedFullRange);
                        break;
                    case Enumerations.OutputSelection.Window:
                        System.Diagnostics.Debug.WriteLine(formattedFullRange);
                        break;

                }
                
                

            }
            catch (Exception ex)
            {
                //Error occurred in the application
                Console.WriteLine("An error has occurred!");
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Gets TokenMapper from config file
        /// </summary>
        /// <returns>TokenMapper derived from config file</returns>
        private static Dictionary<int, string> GetTokenMapper()
        {
            var tokenMapper = new Dictionary<int, string>(); 
            
            //Method to get tokens stored in the app.config file
            NameValueCollection tokenMapperConfigs = (NameValueCollection)ConfigurationManager.GetSection("tokenInfo/tokenSection");
            
            //Check to see if tokens exist
            if (tokenMapperConfigs != null && tokenMapperConfigs.Count > 0)
            {
                //Loop through all tokens in app.config file
                for (int i = 0; i < tokenMapperConfigs.Count; i++)
                {
                    //Add Key / Value to tokenMapper
                    tokenMapper.Add(Convert.ToInt32(tokenMapperConfigs.Keys[i]), tokenMapperConfigs[i].ToString());
                }
            }
            else
            {
                throw new ConfigurationException("tokenInfo/tokenSection configurations are required to run this application");
            }
            return tokenMapper;
        }
    }
}
