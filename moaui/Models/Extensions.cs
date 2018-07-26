using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace moaui.Models
{
    public static class Extensions
    {
        /// <summary>
        /// Trims a string to only allow single whitespace characters between words.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveUnnecessarySpace(this string str) {            
            string newString = "";
            int strIndex = 0;
            bool lettersSeen = false;

            foreach (char c in str) {
                // As long as the lettersSeen flag hasn't been turned on, don't record the whitespace
                // character in the first instance of the [\s][^\s] pattern
                if (!lettersSeen && Regex.IsMatch(c.ToString(), @"[^\s]")) {
                    lettersSeen = true;
                }

                // if the char is a whitespace char and is followed by a non-whitespace character,
                // build this whitespace character into the new string
                if ((strIndex != (str.Length - 1))
                    && Regex.IsMatch(c.ToString() + str[strIndex + 1].ToString(), @"[\s][^\s]")
                    && lettersSeen) {
                    newString += " ";
                }
                else if (Regex.IsMatch(str[strIndex].ToString(), @"[^\s]")) newString += c;

                strIndex++;
            }

            return newString;
        }

        /// <summary>
        /// Converts the user's UserID into a six-digit format.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static string IDFormatting(this int userID) => String.Format("{0:D6}", userID);
    }
}
