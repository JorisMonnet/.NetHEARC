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
                if (b.InsertMove(b.NextMove()))  {
                    r.Draw();
                }
            }
        }
    }
}
