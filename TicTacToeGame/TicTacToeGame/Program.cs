using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.Start();
            Console.ReadKey();
        }
    }

    public class TicTacToe
    {
        Player playerOne;
        Player playerTwo;

        HumanPlayer player = new HumanPlayer('X');
        ComputerPlayer bot = new ComputerPlayer('O');
        Board game = new Board();
        private int turn = 1;

        public TicTacToe()
        {
            Console.CursorVisible = false;
        }

        public void Start()
        {
            Console.Clear();
            int titleRow = 7;
            string[] title = new string[titleRow];
            title[0] = @" _____ ___ ____    _____  _    ____    _____ ___  _____ ";
            title[1] = @"|_   _|_ _/ ___|  |_   _|/ \  / ___|  |_   _/ _ \| ____|";
            title[2] = @"  | |  | | |   _____| | / _ \| |   _____| || | | |  _|  ";
            title[3] = @"  | |  | | |__|_____| |/ ___ \ |__|_____| || |_| | |___ ";
            title[4] = @"  |_| |___\____|    |_/_/   \_\____|    |_| \___/|_____|";
            title[5] = @"                                                        ";
            title[6] = @"                    [MADE BY YUD]                       ";

            for (int i = 0; i < title.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(title[i]);

            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[1] Play");
            Console.WriteLine("[2] How To Play");
            Console.WriteLine("[3] Quit");

            while (true)
            {
                Console.WriteLine();
                Console.Write("press [num] to choose option...");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                {
                    Play(); break;
                }

                if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2)
                {
                    HowToPlay(); break;
                }

                if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad3)
                {
                    Environment.Exit(0); break;
                }
            }
        }

        public void Play()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[PLAY] - CHOOSE YOUR GAME MODE");
            Console.WriteLine();
            Console.WriteLine("[1] Human VS Human");
            Console.WriteLine("[2] Human VS Bot");
            Console.WriteLine("[3] Bot VS Bot");

            while (true)
            {
                Console.WriteLine();
                Console.Write("press [num] to choose option...");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1)
                {
                    PLAYHumanAndHuman(); break;
                }

                if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2)
                {
                    PLAYHumanAndBot(); break;
                }

                if (keyInfo.Key == ConsoleKey.D3 || keyInfo.Key == ConsoleKey.NumPad3)
                {
                    PLAYBotAndBot(); break;
                }
            }

            Console.Clear();
            Console.ResetColor();
            Console.CursorVisible = true;
            game.ResetBoard();

            while (true)
            {
                //playerOne
                if (currentPlayer(playerOne, turn)) break;
                turn++;
                if (turn > 9)
                {
                    isDraw();
                    break;
                }
                if (currentPlayer(playerTwo, turn)) break;
                turn++;
            }
        }

        private void isDraw()
        {
                Console.Clear();
                game.PrintBoard();
                Console.WriteLine();
                Console.WriteLine("[===] [IS A TIE] [===]");
                Console.WriteLine();

        }

        private bool currentPlayer(Player player, int turn)
        {
            
            Console.Clear();
            game.PrintBoard();
            game.PrintGuide();
            Console.WriteLine("-----[Turn {0}]-----", turn);
            if (player.GetMark() == 'X') Console.ForegroundColor = ConsoleColor.Red;
            else Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[{0} {1}]", player.GetName(), player.GetMark());
            player.Turn(game);
            if (player.GetName() == "bot") Thread.Sleep(500);
            if (WinCondition(player.GetMark())) return true;
            Console.ResetColor();
            return false;
        }

        private void PLAYHumanAndHuman()
        {
            turn = 1;
            playerOne = new HumanPlayer('X', "playerOne");
            playerTwo = new HumanPlayer('O', "playerTwo");

        }

        private void PLAYHumanAndBot()
        {
            turn = 1;
            Random rnd = new Random();
            switch (rnd.Next(1, 3))
            {
                case 1:
                    playerOne = new ComputerPlayer('X');
                    playerTwo = new HumanPlayer('O', "player");
                    break;
                case 2:
                    playerOne = new HumanPlayer('X', "player");
                    playerTwo = new ComputerPlayer('O');
                    break;
            }
            
        }

        private void PLAYBotAndBot()
        {
            turn = 1;
            playerOne = new ComputerPlayer('X');
            playerTwo = new ComputerPlayer('O');
        }

        private bool WinCondition(char mark)
        {
            if (game.Logic(mark))
            {
                Console.Clear();
                game.PrintBoard(mark);
                Console.WriteLine();
                Console.WriteLine("[===] [{0} IS WIN] [===]", mark);
                Console.WriteLine();
                return true;
            }
            return false;
        }

        private void HowToPlay()
        {
            while (true)
            {
                Console.Clear();
                
                Console.WriteLine("+ Get 3 marks in a ROW!!");
                HTPRow();
                Console.WriteLine("+ Get 3 marks in a COLLUMN!!");
                HTPCollumn();
                Console.WriteLine("+ Get 3 marks in a DIAGONAL!!");
                HTPDiagonal();

                Console.WriteLine("[HOW TO PLAY]");
                Console.WriteLine("press [1] to back to menu");
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1) { Start(); break; }
                }
                Thread.Sleep(500);
                
            }

        }

        private void HTPDiagonal()
        {
            Random rnd = new Random();
            switch (rnd.Next(1, 3))
            {
                case 1:
                    Console.WriteLine(" ___ ___ ___");
                    Console.WriteLine("| X |   |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("|   | X |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("|   |   | X |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine(); break;
                case 2:
                    Console.WriteLine(" ___ ___ ___");
                    Console.WriteLine("|   |   | X |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("|   | X |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("| X |   |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine(); break;
            }
        }

        private void HTPCollumn()
        {
            Random rnd = new Random();
            switch (rnd.Next(1, 4))
            {
                case 1:
                    Console.WriteLine(" ___ ___ ___");
                    Console.WriteLine("| X |   |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("| X |   |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("| X |   |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine(); break;
                case 2:
                    Console.WriteLine(" ___ ___ ___");
                    Console.WriteLine("|   | X |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("|   | X |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("|   | X |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine(); break;

                case 3:
                    Console.WriteLine(" ___ ___ ___");
                    Console.WriteLine("|   |   | X |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("|   |   | X |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("|   |   | X |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine(); break;
            }
        }

        private void HTPRow()
        {
            Random rnd = new Random();
            switch (rnd.Next(1, 4))
            {
                case 1:
                    Console.WriteLine(" ___ ___ ___");
                    Console.WriteLine("| X | X | X |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("|   |   |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("|   |   |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine(); break;
                case 2:
                    Console.WriteLine(" ___ ___ ___");
                    Console.WriteLine("|   |   |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("| X | X | X |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("|   |   |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine(); break;

                case 3:
                    Console.WriteLine(" ___ ___ ___");
                    Console.WriteLine("|   |   |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("|   |   |   |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine("| X | X | X |");
                    Console.WriteLine("|---|---|---|");
                    Console.WriteLine(); break;
            }
        }
    }
}