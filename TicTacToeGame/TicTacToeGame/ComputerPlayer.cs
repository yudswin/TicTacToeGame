using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TicTacToeGame
{
    public class ComputerPlayer : Player
    {
        private int prePlayerX;
        private int preYPlayerY;
        private int streak = 0;
        public ComputerPlayer(char mark) : base(mark) { }


        public sealed override void Turn(Board board)
        {
            if (board.CheckFreeSpace() == 0) return;
            Random rnd = new Random();
            while(true)
            {
                int row = rnd.Next(1, board.Map.GetLength(0));
                int collumn = rnd.Next(1, board.Map.GetLength(0));
                if (board.NewMove(row, collumn, GetMark())) break;
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