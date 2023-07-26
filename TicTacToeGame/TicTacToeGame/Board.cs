using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    public class Board
    {
        // Data field
        private char[,] map; // [row, collumn]
        private List<Point> markXhis = new List<Point>();
        private List<Point> markYhis = new List<Point>();


        // Properties
        public char[,] Map { get => map; set => map = value; }


        // Constructor
        public Board()
        {
            Map = new char[4, 4];
        }


        public int CheckFreeSpace()
        {
            int free = 0;
            foreach(char mark in map)
            {
                if (mark == ' ') free++;
            }
            return free;
        }

        // Methods
        public  bool NewMove(int row, int collumn, char mark)
        {

            if (map[row, collumn] == ' ')
            {
                map[row, collumn] = mark;
                if (mark == 'X') markXhis.Add(new Point(row, collumn));
                else markYhis.Add(new Point(row, collumn));
                return true;
            } 
            return false;
        }

        public bool Logic()
        {
            // Check rows
            for (int row = 0; row < 4; row++)
            {
                if (map[row, 0] == map[row, 1] && map[row, 0] == map[row, 2] && map[row, 0] == map[row, 3] && map[row, 0] != ' ')
                {
                    return true;
                }
            }

            // Check columns
            for (int col = 0; col < 4; col++)
            {
                if (map[0, col] == map[1, col] && map[0, col] == map[2, col] && map[0, col] == map[3, col] && map[0, col] != ' ')
                {
                    return true;
                }
            }

            // Check main diagonal (top-left to bottom-right)
            if (map[0, 0] == map[1, 1] && map[0, 0] == map[2, 2] && map[0, 0] == map[3, 3] && map[0, 0] != ' ')
            {
                return true;
            }

            // Check secondary diagonal (top-right to bottom-left)
            if (map[0, 3] == map[1, 2] && map[0, 3] == map[2, 1] && map[0, 3] == map[3, 0] && map[0, 3] != ' ')
            {
                return true;
            }

            return false;
        }

        public bool MarkAvailable(Point point)
        {
            foreach (char mark in map)
            {
                if (map[point.X, point.Y] != ' ') return true;
            }
            return false;
        }

        public void ResetBoard()
        {
            for (int i = 1; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    Map[i, j] = ' ';
                }
            }
        }
        
        public void PrintBoard()
        {
            
            Console.WriteLine(" ___ ___ ___");
            Console.WriteLine("| {0} | {1} | {2} |  1", map[1, 1], map[1, 2], map[1, 3]);
            Console.WriteLine("|---|---|---|     R");
            Console.WriteLine("| {0} | {1} | {2} |  2  O", map[2, 1], map[2, 2], map[2, 3]);
            Console.WriteLine("|---|---|---|     W");
            Console.WriteLine("| {0} | {1} | {2} |  3", map[3, 1], map[3, 2], map[3, 3]);
            Console.WriteLine("|---|---|---|");
            Console.WriteLine("  1   2   3 ");
            Console.WriteLine();
            Console.WriteLine("   COLLUMN ");
            Console.WriteLine();
        }

    }
}
