using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame
{
    public abstract class Player : IPlayer
    {
        protected char mark;

        public Player(char mark)
        {
            this.mark = mark;
        }


        public char GetMark()
        {
            return mark;
        }
        public abstract string IsLose();
        public abstract string IsTied();
        public abstract string IsWinner();
        public abstract void Turn(Board board);


    }
}