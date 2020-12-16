using System.Collections.Generic;

namespace BoxCorp.App
{
    public class RealRankComparer : Comparer<Box>
    {
        private readonly List<int> _ignoredBoxes = new List<int>();

        public ICollection<int> IgnoredBoxes => _ignoredBoxes;

        public override int Compare(Box x, Box y)
        {
            var jaqardIndex = x.JaqardIndexWith(y);

            // no intersect, keep both
            if (jaqardIndex == 0)
            {
                return 0;
            }

            if (jaqardIndex > Consts.JaqardIndexThreshold)
            {
                if (x.Rank > y.Rank)
                {
                    _ignoredBoxes.Add(y.Id);
                    return 1;
                }

                if (x.Rank < y.Rank)
                {
                    _ignoredBoxes.Add(x.Id);
                    return -1;
                }

                //same rank
                return 0;
            }

            if (jaqardIndex < Consts.JaqardIndexThreshold)
            {
                if (x.Rank > y.Rank)
                {
                    _ignoredBoxes.Add(x.Id);
                    return -1;
                }

                if (x.Rank < y.Rank)
                {
                    _ignoredBoxes.Add(y.Id);
                    return 1;
                }

                return 0;
            }

            return 0; //keep if jqard index == threshold
        }
    }
}
