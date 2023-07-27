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
            TicTacToe game = new TicTacToe();
            game.Play();
            Console.ReadKey();
        }
    }

    public class TicTacToe
    {
        HumanPlayer player = new HumanPlayer('X');
        ComputerPlayer bot = new ComputerPlayer('O');
        Board game = new Board();
        private int turn = 1;

        public TicTacToe()
        {

            
        }

        public void Play()
        {
            game.ResetBoard();
            game.PrintBoard();
            while (true)
            {
                Console.WriteLine("-----[Turn {0}]-----", turn);
                player.Turn(game);
                if (WinCondition(player.GetMark())) break;
                bot.Turn(game);
                if (WinCondition(bot.GetMark())) break;

                if (game.CheckFreeSpace() == 0)
                {
                    game.PrintBoard();
                    Console.WriteLine();
                    Console.WriteLine("[===] [IS A TIE] [===]");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.Clear();
                    game.PrintBoard();
                }
                turn++;
            }
        }

        public bool WinCondition(char mark)
        {
            if (game.Logic(mark))
            {
                Console.Clear();
                game.PrintBoard();
                Console.WriteLine();
                Console.WriteLine("[===] [{0} IS WIN] [===]",mark);
                Console.WriteLine();
                return true;
            }
            return false;
        }
    }
}
