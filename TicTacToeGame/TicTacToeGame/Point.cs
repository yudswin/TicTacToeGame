using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame
{
    public class Point
    {
        private int x, y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}