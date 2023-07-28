using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame
{
    public abstract class Player : IPlayer
    {
        protected char mark;
        protected string name = "bot";

        public Player(char mark)
        {
            this.mark = mark;
        }

        public Player(char mark, string playerName)
        {
            this.mark = mark;
            this.name = playerName;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string newName)
        {
            this.name = newName;
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