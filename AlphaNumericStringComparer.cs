using System.Collections.Generic;

namespace nl.mijnaansluiting.sorting
{
    public class AlphaNumericStringComparer : IComparer<string>
    {
        #region Public Methods

        public int Compare(string left, string right)
        {
            return new AlphaNumericString(left).CompareTo(new AlphaNumericString(right));
        }

        #endregion Public Methods
    }
}