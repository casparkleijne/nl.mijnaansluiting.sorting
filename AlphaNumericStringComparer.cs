using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace nl.mijnaansluiting.sorting
{
    public class AlphaNumericStringComparer : IComparer<string>
    {
        #region Private Fields

        private static readonly Regex regex = new Regex(@"((?<negativeint>[\-\+\$][\d]+)|(?<int>[\d]+)|(?<stringlower>[a-z]+)|(?<stringupper>[A-Z]+)|(?<special>[\s]+))", RegexOptions.Singleline);

        #endregion Private Fields

        #region Private Methods

        private static string FindGroupName(Match match)
        {
            return match.Groups
                .Cast<Group>()
                .Where((group, index) => group.Success && !group.Name.Equals($"{index}"))
                .Select(x => x.Name)
                .FirstOrDefault();
        }

        private static string MatchEvaluator(Match match)
        {
            switch (FindGroupName(match))
            {
                case "negativeint":
                    var value1 = $".{match.Value.Replace("-", string.Empty)}1".PadLeft(16, '0');
                    return value1;

                case "int":
                    var value2 = $".{match.Value}0".PadLeft(16, '0');
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

        private static string Parse(string value)
        {
            return regex.Replace(value, MatchEvaluator);
        }

        #endregion Private Methods

        #region Public Methods

        public int Compare(string left, string right)
        {
            int result = Parse(left).CompareTo(Parse(right));
            return result == 0 ? right.CompareTo(left) : result;
        }

        #endregion Public Methods
    }
}