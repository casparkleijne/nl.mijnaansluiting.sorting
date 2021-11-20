using System;

namespace nl.mijnaansluiting.sorting
{
    internal class AlphaNumericString : IComparable<AlphaNumericString>
    {
        #region Private Fields

        private readonly string value;

        #endregion Private Fields

        #region Public Constructors

        public AlphaNumericString(string value)
        {
            this.value = value;
        }

        #endregion Public Constructors

        #region Public Methods

        public string ComparerValue()
        {
            return AlphaNumericStringEvaluator.Replace(value);
        }

        public int CompareTo(AlphaNumericString other)
        {
            return ComparerValue().CompareTo(other.ComparerValue() ?? string.Empty);
        }

        #endregion Public Methods
    }
}