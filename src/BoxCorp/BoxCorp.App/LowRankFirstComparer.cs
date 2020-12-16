using System.Collections.Generic;

namespace BoxCorp.App
{
    /// <summary>
    /// Low rank first to make the result consistent and remvoval easy
    /// </summary>
    public class LowRankFirstComparer : Comparer<Box>
    {
        public override int Compare(Box x, Box y)
        {
            return x.Rank.CompareTo(y.Rank);
        }
    }
}
