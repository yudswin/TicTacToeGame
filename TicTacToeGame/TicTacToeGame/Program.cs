using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HumanPlayer playerOne = new HumanPlayer('X');
            ComputerPlayer playerTwo = new ComputerPlayer('O');
            Board game = new Board();
            game.ResetBoard();
            game.PrintBoard();


            int turn = 1;
            

            while (true)
            {
                Console.WriteLine("-----[Turn {0}]-----",turn);
                playerOne.Turn(game);
                if (!game.Logic()) break;
                playerTwo.Turn(game);
                if (!game.Logic()) break;

                if (game.CheckFreeSpace() == 0)
                {
                    game.PrintBoard();
                    break;
                } else game.PrintBoard();
                turn++;
                
            }


            Console.ReadKey();
        }
    }
}
