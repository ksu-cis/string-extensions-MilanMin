using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExtensionMethods
{
    public static class StringExtensions
    {

        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?', '\t', '\n', '!' }, StringSplitOptions.RemoveEmptyEntries).Length; 
        }

        public static string Capitalize(this string str)
        {
            return Convert.ToString(str[0]).ToUpper() + str.Substring(1);
        }

        public static void Decapitalize(this string str)
        {
            str =  Convert.ToString(str[0]).ToLower() + str.Substring(1);
        }

        public static string Titleize(this string title)
        {
            List<string> splitString = new List<string>(title.Split(" "));
            List<string> articles = new List<string>()
            {
                "a",
                "an",
                "the"
            };

            string first = splitString[0];

            if (articles.Contains(first.ToLower()))
            {
                splitString.RemoveAt(0);
                splitString.Add(", " + first);
                first = splitString[0];
                while (articles.Contains(first.ToLower()))
                {
                    splitString.RemoveAt(0);
                    splitString.Add(" ");
                    splitString.Add(first);
                    first = splitString[0];
                }

                string result = "";
                foreach(string part in splitString)
                {
                    result += part + " ";
                }
                return result;
            }

            return title;
        }
    }
}
