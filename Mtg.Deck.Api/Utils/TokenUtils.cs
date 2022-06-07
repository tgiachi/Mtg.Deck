using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mtg.Deck.Api.Utils
{
    public class TokenUtils
    {

        public static int ExtractManaToken(string value)
        {
            var result = 0;
            var regEx = new Regex(@"\{([^}]*)\}");
            foreach (Match match in regEx.Matches(value))
            {
                var val = match.Value.Replace("{", "").Replace("}", "");
                if (val.All(char.IsDigit))
                {
                    var number = int.Parse(val);
                    result += number;
                }
                else
                {
                    result += 1;
                }
            }

            return result;
        }
    }
}
