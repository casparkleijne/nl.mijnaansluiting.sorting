using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace nl.mijnaansluiting.sorting
{
    public class AlphaNumericStringComparer : IComparer<string>
    {
        #region Private Fields

        private static readonly Regex regex = new Regex(@"((?<intnegative>[\-\+\$][\d]+)|(?<int>[\d]+)|(?<stringlower>[a-z]+)|(?<stringupper>[A-Z]+)|(?<special>[\s]+))", RegexOptions.Singleline);
        private readonly int paddingTotalWidth;

        public AlphaNumericStringComparer(int paddingTotalWidth = 16)
        {
            this.paddingTotalWidth = paddingTotalWidth;
        }

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

        private string MatchEvaluator(Match match)
        {
            switch (FindGroupName(match))
            {
                case "intnegative":
                    var value1 = $"A{match.Value.Replace("-", string.Empty)}0".PadLeft(paddingTotalWidth, '0');
                    return value1;

                case "int":
                    var value2 = $"A{match.Value}1".PadLeft(paddingTotalWidth, '0');
                    return value2;

                case "stringlower":
                    return $"C{match.Value}";

                case "stringupper":
                    return $"D{match.Value}";

                case "special":
                    return $"E{match.Value}";

                default:
                    return $"F{match.Value}";
            }
        }

        private string Parse(string value)
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