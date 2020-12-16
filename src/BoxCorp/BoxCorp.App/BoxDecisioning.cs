using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxCorp.App
{
    public class BoxDecisioning
    {
        private readonly List<Box> _sortedList = new List<Box>();

        private const decimal LowRankThreshold = 0.5M;

        public int BoxCount => _sortedList.Count;

        public void Push(Box box)
        {
            _sortedList.Add(box);
        }

        public void RemoveLowRankBoxes()
        {
            _sortedList.Sort(new LowRankFirstComparer());

            var rank = _sortedList.FirstOrDefault()?.Rank;
            while (rank.HasValue && rank.Value < LowRankThreshold)
            {
                _sortedList.RemoveAt(0);
                rank = _sortedList.FirstOrDefault()?.Rank;
            }
        }

        public void Decisioning()
        {
            _sortedList.Sort();

            for (int i = _sortedList.Count - 1; i >= 0; i--)
            {
                Box item = _sortedList[i];
                if (item.Ignored)
                {
                    _sortedList.Remove(item);
                }
            }
        }
    }
}
