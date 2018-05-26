using System;

namespace moaui.Models
{
    public static class Extensions
    {
        /// <summary>
        /// Removes multiple, consecutive instances of a space (' ') character.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveUnnecessarySpace(this string str) {
            /* TODO: as of now this only looks at ONE non-TrimStart space. it needs to look
             * at all instances of consecutive space characters rather than just the first.
             * eg "Jane A. Doe" will become "Jane A.Doe"
             *
             * Perhaps this could be better handled by regex? (See usage in User.cs) */

            if (str.Contains(" ")) {
                int charIndex = str.IndexOf(' ');

                return str.Substring(0, charIndex + 1) +
                       str.Substring(charIndex, str.Length - charIndex)
                       .Replace(' '.ToString(), String.Empty).Trim();
            }
            else return str;
        }

        /// <summary>
        /// Converts the user's UserID into a six-digit format.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static string IDFormatting(this int userID) => String.Format("{0:D6}", userID);
    }
}
