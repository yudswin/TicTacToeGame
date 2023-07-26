using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame
{
    public interface IPlayer
    {
        char GetMark();
        string IsWinner();
        string IsLose();
        string IsTied();
        void Turn(Board board);
    }
}