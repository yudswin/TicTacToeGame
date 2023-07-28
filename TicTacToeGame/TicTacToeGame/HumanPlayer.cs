using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TicTacToeGame
{
    public class HumanPlayer : Player
    {


        public HumanPlayer(char mark) : base(mark) { }
        public HumanPlayer(char mark, string playerName) : base(mark, playerName) { }

        public sealed override void Turn(Board board)
        {
            while (true)
            {
                try
                { 
                    Console.Write("Enter number between 1-9: ");
                    int num = int.Parse(Console.ReadLine());
                    if (board.NewMove(NumToCordinate(num), GetMark())) break;
                }
                catch (Exception)
                {
                    Console.Write("Invalid Input.");
                }
            }
        }

        public Point NumToCordinate(int num)
        {
            int row, collumn;
            row = (num - 1) / 3 + 1;
            collumn = num % 3 == 0 ? 3 : num % 3;

            return new Point(row, collumn);

        } 

        public sealed override string IsLose()
        {
            return "YOU LOSE";
        }

        public sealed override string IsTied()
        {
            return "IS A TIE";
        }

        public sealed override string IsWinner()
        {
            return "YOU WIN!";
        }

    }
}