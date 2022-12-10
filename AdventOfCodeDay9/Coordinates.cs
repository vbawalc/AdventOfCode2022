using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeDay9
{
    internal class Coordinates
    {
        int x;
        int y;
        public int X => x;
        public int Y => y;

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Coordinates operator + (Coordinates coordinates1, Coordinates coordinates2)
        {
            return new Coordinates(coordinates1.x + coordinates2.x, coordinates1.y + coordinates2.y);
        }
        public static Coordinates operator -(Coordinates coordinates1, Coordinates coordinates2)
        {
            return new Coordinates(coordinates1.x - coordinates2.x, coordinates1.y - coordinates2.y);
        }
    }
}
