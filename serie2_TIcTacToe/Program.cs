using System;

namespace TIcTacToe
{
    class Program
    {
        static void Main() {
            Board b = new Board(new Player('X'), new Player('O'));
            Render r = new Render(b);
            r.Draw();

            while (!b.IsFinished() || b.DoRestart()) {
                var (x, y) = b.NextMove();
                if (b.InsertMove(x,y))  {
                    r.Draw();
                }
            }
        }
    }
}
