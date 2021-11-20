using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace nl.mijnaansluiting.sorting
{
    internal sealed class AlphaNumericStringEvaluator
    {
        #region Private Fields

        /// <summary>
        /// filters out all automatic named groups and returns only the "real-names"
        /// </summary>
        private static readonly Func<Group, int, bool> groupFilter = (group, index) => !group.Name.Equals($"{index}") && group.Success;

        /// <summary>
        /// The regex that parses the string to be compared
        /// </summary>
        private static readonly Regex regex = new Regex(@"((?<int>\d+)|(?<string>[A-Za-z-]+)|(?<special>[\W\s]+))", RegexOptions.IgnoreCase | RegexOptions.Singleline);

        #endregion Private Fields

        #region Private Methods

        private static string Evaluate(Match match)
        {
            if (match is null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            Group group = FindGroup(match);

            if (group is null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            switch (group.Name ?? string.Empty)
            {
                case "int":
                    return match.Value.PadLeft(16, '0');

                case "string":
                    return match.Value.ToLower();

                case "special":
                    return ".";

                default:
                    return "";
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
                .Where(groupFilter)
                .FirstOrDefault();
        }

        #endregion Private Methods

        #region Public Methods

        /// <summary>
        /// replaces a part of the string with another string
        /// </summary>
        /// <param name="value">the string value to be looked up and replaced</param>
        /// <returns></returns>
        public static string Replace(string value)
        {
            return regex.Replace(value, Evaluate);
        }

        #endregion Public Methods
    }
}
