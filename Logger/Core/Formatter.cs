using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Logging.Core
{
    public static class Formatter
    {

        public static Dictionary<string, object> FormatString(string input, params object[] parameters)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            Regex regex = new Regex(@"\b*{\w+}\b*");
            var matches = regex.Matches(input).OfType<Match>().GroupBy(e => e.Value).Select(e => e.First()).ToList();

            if (matches.Count == parameters.Length)
            {
                for (int i = 0; i < matches.Count; ++i)
                {
                    Match match = matches[i];
                    result.Add(match.Value.Replace("{", "").Replace("}", ""), parameters[i]);

                }
            }
            else
            {
                throw new ArgumentException("Number of variables not equal to number of parameters");
            }

            return result;
        }

    }
}
