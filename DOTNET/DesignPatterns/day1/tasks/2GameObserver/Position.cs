using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GameObserver
{
    internal class Position
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Position(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Position pos)
            {
                return pos.X == X && pos.Y == Y && pos.Z == Z;
            }

            return false;
        }
    }
}
