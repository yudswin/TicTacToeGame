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

        public sealed override void Turn(Board board)
        {
            while (true)
            {
                Console.Write("enter ROW cordinates : ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("enter COLLUMN cordinates : ");
                int collumn = int.Parse(Console.ReadLine());

                //  Exception 
                row.Should().BeInRange(1, board.Map.GetLength(0));
                collumn.Should().BeInRange(1, board.Map.GetLength(1));

                if (board.NewMove(row, collumn, GetMark())) break;
                else Console.WriteLine("error cordinates!!");
            }

            
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