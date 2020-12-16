using System.Collections.Generic;

namespace BoxCorp.App
{
    public class BoxDecisioning
    {
        private readonly SortedList<int, Box> _list = new SortedList<int, Box>();

        private readonly SortedList<decimal, Box> _sortedList = new SortedList<decimal, Box>(new HighRankFirstComparer());

        public int BoxCount => _list.Count;

        public void Push(int id, Box box)
        {
            if (box.Rank < Consts.LowRankThreshold)
            {
                return;
            }

            _list.Add(id, box);

            _sortedList.Add(box.Rank, box);
        }

        public ICollection<Box> Decisioning()
        {
            var comparer = new RealRankComparer();
            var set = new SortedSet<Box>(_sortedList.Values, comparer);

            foreach (var id in comparer.IgnoredBoxes)
            {
                _list.Remove(id);
            }

            return _list.Values;
        }
    }
}
