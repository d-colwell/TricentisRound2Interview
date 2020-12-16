using System;
using System.Drawing;

namespace BoxCorp.App
{
    public class Box : IComparable<Box>
    {
        public Box(int x, int y, int width, int height, decimal rank)
        {
            Rectangle = Rectangle.FromLTRB(x, y, x + width, y + height);
            Rank = rank;
            Ignored = false;
        }

        public Rectangle Rectangle { get; }

        public decimal Rank { get; }

        public bool Ignored { get; private set; }

        public int CompareTo(Box other)
        {
            var jaqardIndex = JaqardIndexWith(other);

            // no intersect, keep both
            if (jaqardIndex == 0)
            {
                return 0;
            }

            if (jaqardIndex > Consts.JaqardIndexThreshold)
            {
                if (Rank > other.Rank)
                {
                    other.Ignored = true;
                    return 1;
                }

                if (Rank < other.Rank)
                {
                    this.Ignored = true;
                    return -1;
                }

                //same rank
                return 0;
            }

            if (jaqardIndex < Consts.JaqardIndexThreshold)
            {
                if (Rank > other.Rank)
                {
                    this.Ignored = true;
                    return -1;
                }

                if (Rank < other.Rank)
                {
                    other.Ignored = true;
                    return 1;
                }

                return 0;
            }


            return 0; //keep if == threshold
        }

        public double JaqardIndexWith(Box other)
        {
            if (!this.Rectangle.IntersectsWith(this.Rectangle))
            {
                return 0;
            }

            var intersect = Rectangle.Intersect(this.Rectangle, other.Rectangle);
            var intersectArea = intersect.Width * intersect.Height;

            var unionArea = this.Rectangle.Width * this.Rectangle.Height + other.Rectangle.Width * other.Rectangle.Height - intersectArea;

            return Math.Floor(100.0 * intersectArea / unionArea) / 100;
        }
    }
}
