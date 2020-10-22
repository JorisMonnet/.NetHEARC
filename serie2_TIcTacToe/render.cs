using System;
using System.Linq;
using System.Text;

public class Render
{
	private Board b;
	public Render(Board board){
		b = board;
	}
	public void Draw(){
        Console.Clear();
        for (int x = 0; x < 3; x++)  {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < 3; y++) {
                sb.Append((y == 0) ? "  " : "  |  ");
                sb.Append((b[x,y] != null) ? b[x,y].ToString() : " ");
            }
            if (x < 2) sb.Append("\n-----+-----+-----");
            Console.WriteLine(sb);
        }
        Console.WriteLine();
    }
}
