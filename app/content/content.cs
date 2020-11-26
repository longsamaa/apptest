using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace app.content
{
    public class content
    {
        public static List<string> find(string searchString, List<string> lines)
        {
            var pattern = searchString.ToUpper();
            Regex rgx = new Regex(pattern); 
            List<string> result = new List<string>();
            string symbol = @"[\""\'\\]+"; 
            foreach(string line in lines)
            {
                Match match = rgx.Match(line.ToUpper()); 
                if(match.Success)
                { 
                    string result2;
                    if (content.format(line, symbol, searchString, out result2))
                    {
                        result.Add(result2); 
                    }
                    else
                    {
                        result.Add(line); 
                    }
                }
            }    
            return result; 
        }

        public static bool format(string text,string symbol,string target,out string result)
        {
            result = string.Empty; 
            Regex rgx = new Regex(symbol);
            Match match = rgx.Match(text); 
            if(match.Success)
            {
                Regex rgx2 = new Regex(target.ToUpper());
                Match match2 = rgx2.Match(text.ToUpper());
                if (match2.Success)
                {
                    if (match2.Index >= 0)
                    {
                        string temp = string.Empty;
                        for (int i = match2.Index; i < text.Length; i++)
                        {

                            if (Convert.ToInt32(text[i]) != 92)
                            {
                                temp += text[i];
                            }
                            else
                            {
                                break;
                            }
                        }
                        result = temp;
                        return true;
                    }
                }
            }
            return false; 
        }
    }
}
