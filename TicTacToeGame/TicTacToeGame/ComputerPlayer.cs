using System;

namespace TicTacToeGame
{
    public class ComputerPlayer : Player
    {

        private static Point newMove;
        private static Point preMove;

        private Point defaultMove = new Point(0, 0);

        public ComputerPlayer(char mark) : base(mark) { }


        public sealed override void Turn(Board board)
        {
            if (board.CheckFreeSpace() == 0) return;
            Random rnd = new Random();
            Point defmove = PosibleMove();
            if (board.NewMove(defmove.X, defmove.Y, GetMark())) return;
            else
            {
                while (true)
                {
                    int row = rnd.Next(1, board.Map.GetLength(0));
                    int collumn = rnd.Next(1, board.Map.GetLength(0));
                    if (board.NewMove(row, collumn, GetMark())) break;
                }
            }
        }

        public void GetNewMove()
        {
            newMove = Board.MarkXhis[Board.GetXHisLength - 1];
        }

        public Point PosibleMove()
        {
            if (newMove == null)
            {
                newMove = defaultMove;
                return defaultMove;
            }
            else
            {
                preMove = newMove;
                GetNewMove();
            }

            switch (GetType(newMove))
            {
                case Type.CORNER:
                    if (GetType(preMove) == Type.CORNER) // PreMove is CORNER
                    {
                        // NewMove Same Collumn
                        if (newMove.Y == preMove.Y) return new Point(2, newMove.Y);
                        // NewMove Same Row
                        else if (newMove.X == preMove.X) return new Point(newMove.X, 2);
                        // Opposite CORNER
                        else return new Point(2, 2);
                    }
                    else if (GetType(preMove) == Type.CENTER) // PreMove Is CENTER
                    {
                        // NewMove is Top Left or Bottom Right CORNER
                        if (newMove.X == newMove.Y)
                        {
                            if (newMove.X == 1) return new Point(3, 3);
                            else return new Point(1, 1);
                        }
                        else
                        {
                            if (newMove.X == 1) return new Point(3, 1);
                            else return new Point(1, 3);
                        }
                    }
                    else // PreMove Is MIDDLE
                    {
                        // NewMove Same Collumn
                        if (newMove.Y == preMove.Y)
                        {
                            if (preMove.X == 1) return new Point(3, newMove.Y);
                            else return new Point(1, newMove.Y);
                        } else if (newMove.X == preMove.X)
                        {
                            if (preMove.Y == 1) return new Point(newMove.X, 3);
                            else return new Point(newMove.X, 1);
                        }
                    }
                    break;
                case Type.MIDDLE:
                    if (GetType(preMove) == Type.CENTER) // PreMove is CENTER
                    {
                        if(newMove.X == preMove.X)
                        {
                            if (preMove.X == 1) return new Point(preMove.X, 3);
                            else return new Point(newMove.X, 1);
                        } else if (newMove.Y == preMove.Y)
                        {
                            if (preMove.Y == 1) return new Point(3, preMove.Y);
                            else return new Point(1, preMove.Y);
                        } 
                    } else if (GetType(preMove) == Type.CORNER) // PreMove is CORNER
                    {
                        if (newMove.X == preMove.X)
                        {
                            if (preMove.X == 1) return new Point(preMove.X, 3);
                            else return new Point(preMove.X, 1);
                        }
                        else if (newMove.Y == preMove.Y)
                        {
                            if (preMove.Y == 1) return new Point(3, preMove.Y);
                            else return new Point(1, preMove.Y);
                        }
                    }
                    break;
            }

            return defaultMove;
        }

        public Type GetType(Point move)
        {
            //Center
            if (move == new Point(2, 2)) return Type.CENTER;

            //Corner
            for (int i = 1; i <= 3; i += 3)
            {
                for (int j = 1; j <= 3; j += 2)
                {
                    if (move == new Point(i, j)) return Type.CORNER;
                }
            }

            return Type.MIDDLE;

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