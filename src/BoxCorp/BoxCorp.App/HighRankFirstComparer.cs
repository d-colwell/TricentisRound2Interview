using System.Collections.Generic;

namespace BoxCorp.App
{
    public class HighRankFirstComparer : Comparer<decimal>
    {
        public override int Compare(decimal x, decimal y)
        {
            return y.CompareTo(x);
        }
    }
}