using System;
using System.Drawing;

namespace BoxCorp.App
{
    public class Box
    {
        public int Id { get; }

        public Rectangle Rectangle { get; }

        public decimal Rank { get; }

        public Box(int id, int x, int y, int width, int height, decimal rank)
        {
            Id = id;
            Rectangle = Rectangle.FromLTRB(x, y, x + width, y + height);
            Rank = rank;
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
