using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace nl.mijnaansluiting.sorting
{
    public class AlphaNumericStringComparer : IComparer<string>
    {
        #region Private Fields

        /// <summary>
        /// The regex that parses the string to be compared
        /// </summary>
        private static readonly Regex regex = new Regex(@"((?<negativeint>-[\d]+)|(?<int>[\d]+)|(?<stringlower>[a-z]+)|(?<stringupper>[A-Z]+)|(?<special>[\s]+))", RegexOptions.Singleline);

        #endregion Private Fields

        #region Private Methods

        private static string Evaluate(Match match)
        {
            switch (FindGroup(match)?.Name ?? string.Empty)
            {
                case "negativeint":
                    var value1 = $"{match.Value.Replace("-", string.Empty)}1".PadLeft(16, '0');
                    return value1;

                case "int":
                    var value2 = $"{match.Value}0".PadLeft(16, '0');
                    return value2;

                case "stringlower":
                    return $"A{match.Value}";

                case "stringupper":
                    return $"Z{match.Value}";

                case "special":
                    return $"[{match.Value}";

                default:
                    return $"/{match.Value}";
            }
        }

        /// <summary>
        /// Finds the group of the match as defined by name in the regular expression.
        /// </summary>
        /// <param name="match">the match</param>
        /// <returns></returns>
        private static Group FindGroup(Match match)
        {
            return match.Groups
                .Cast<Group>()
                .Where((group, index) => !group.Name.Equals($"{index}") && group.Success)
                .FirstOrDefault();
        }

        #endregion Private Methods

        #region Public Methods

        public int Compare(string left, string right)
        {
            int result = regex.Replace(left, Evaluate).CompareTo(regex.Replace(right, Evaluate));
            return result == 0 ? right.CompareTo(left) : result;
        }

        #endregion Public Methods
    }
}