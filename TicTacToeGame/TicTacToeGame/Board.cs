using FluentAssertions.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    public class Board
    {
        // Data field
        private const int BOARD_SIZE = 3;
        private static char[,] map; // [row, collumn]
        private static List<Point> markXhis = new List<Point>();
        private static List<Point> markYhis = new List<Point>();


        // Properties
        public char[,] Map { get => map; set => map = value; }
        public static int GetXHisLength { get => MarkXhis.Count; }
        public static int GetYHisLength { get => MarkYhis.Count; }
        public static List<Point> MarkXhis { get => markXhis; }
        public static List<Point> MarkYhis { get => markYhis; }


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

                if (mark == 'X') MarkXhis.Add(new Point(row, collumn));
                else MarkYhis.Add(new Point(row, collumn));
                Console.Beep();
                return true;
            }
            return false;
        }

        public bool NewMove(Point point, char mark)
        {
            if(!NewMove(point.X,point.Y, mark))
            {
                Console.WriteLine("Mark has been placed! Please change...");
                return false;
            }
            return true;
        }

        public bool Logic(char mark)
        {
            // Check rows
            for (int row = 1; row <= BOARD_SIZE; row++)
            {
                if (map[row, 1] == map[row, 2] && map[row, 1] == map[row, 3] && map[row, 1] == mark) return true;
            }

            // Check columns
            for (int collumn = 1; collumn <= BOARD_SIZE; collumn++)
            {
                if (map[1,collumn] == map[2,collumn] && map[1,collumn] == map[3,collumn] && map[1,collumn] == mark) return true;
            }

            // Check main diagonal (top-left to bottom-right)
            if (map[1, 1] == map[2, 2] && map[1, 1] == map[3, 3] && map[1, 1] == mark) return true;

            // Check secondary diagonal (top-right to bottom-left)
            if (map[1, 3] == map[2, 2] && map[1, 3] == map[3, 1] && map[1, 3] == mark) return true;

            // Return false when no win condition meet
            return false;
        }

        public static bool MarkAvailable(int row, int collumn)
        {    
            if (map[row, collumn] != ' ') return true;
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
            Console.ResetColor();   
            Console.WriteLine(" ___ ___ ___");
            Console.WriteLine("| {0} | {1} | {2} |", map[1, 1], map[1, 2], map[1, 3]);
            Console.WriteLine("|---|---|---|");
            Console.WriteLine("| {0} | {1} | {2} |", map[2, 1], map[2, 2], map[2, 3]);
            Console.WriteLine("|---|---|---|");
            Console.WriteLine("| {0} | {1} | {2} |", map[3, 1], map[3, 2], map[3, 3]);
            Console.WriteLine("|---|---|---|");
            Console.WriteLine();
        }

        public void GetLine(int row, char winner)
        {
            for(int i = 1; i <= BOARD_SIZE; i++)
            {
                Console.Write("| ");
                if (map[row,i] == winner)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0} ", map[row, i]);
                    Console.ResetColor();
                }
                else Console.Write("{0} ", map[row, i]);
            }
            Console.Write("|\n");
        }

        public void PrintBoard(char winner)
        {
            Console.ResetColor();
            Console.WriteLine(" ___ ___ ___");
            GetLine(1,winner);
            Console.WriteLine("|---|---|---|");
            GetLine(2, winner);
            Console.WriteLine("|---|---|---|");
            GetLine(3, winner);
            Console.WriteLine("|---|---|---|");
            Console.WriteLine();
        }

        public void PrintGuide()
        {

            Console.WriteLine(" ___ ___ ___");
            Console.WriteLine("| 1 | 2 | 3 |");
            Console.WriteLine("|---|---|---|");
            Console.WriteLine("| 4 | 5 | 6 |");
            Console.WriteLine("|---|---|---|");
            Console.WriteLine("| 7 | 8 | 9 |");
            Console.WriteLine("|---|---|---|");
            Console.WriteLine();
        }

    }
}
