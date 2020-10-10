using System;

public class Board
{
	private Player currentPlayer,nextPlayer;
    public string[] field = new string[9];
    public Board(Player p1,Player p2) {
        currentPlayer = p1;
        nextPlayer = p2;
        Initfield();
	}
    public void Initfield(){
        for(int i=0;i<9;i++){
            field[i] = i.ToString();
        }
    }
    public bool InsertMove(int position) {
        if (position <9 && position>-1&&field[position]!=nextPlayer.ToString()&& field[position] != currentPlayer.ToString()) {
            field[position] = currentPlayer.ToString();
            (currentPlayer, nextPlayer) = (nextPlayer, currentPlayer);
        } else {Console.WriteLine("Move not valid !\n");}
        return (position < 9 && position > -1);
    }
    public bool IsCompleted(){
        for (int i = 0; i < 9; i++) {
            if (field[i] == i.ToString()) return false;
        }
        return true;
    }
    
    public bool IsFinished(){
        bool statement = false;
        for (int i = 0; i < 3; i++) {
            if (field[i] == field[i + 1] && field[i] == field[i + 2]) statement = true;
            if (field[i] == field[i + 3] && field[i] == field[i + 6]) statement = true;
        }
        if (field[0] == field[2] && field[0] == field[4]) statement = true;
        if (field[2] == field[4] && field[2] == field[6]) statement = true;
        if (statement){
            nextPlayer.nbVictory++;
            Console.WriteLine($"Player {nextPlayer} won ! Victories : Player {nextPlayer}:{nextPlayer.nbVictory}\tPlayer {currentPlayer}:{currentPlayer.nbVictory}");
            return true;
        }
        if (IsCompleted()){
            Console.WriteLine($"Draw ! Victories : Player{currentPlayer}:{currentPlayer.nbVictory}\tPlayer {nextPlayer}:{nextPlayer.nbVictory}");
            return true;
        }
        return false;
    }

    public int NextMove()  {
        do {
            Console.Write($"Player {currentPlayer} please enter number : ");
            try{
                return int.Parse(Console.ReadLine());
            }
            catch {Console.WriteLine("Wrong coordinates format");}
        } while (true);
    }
    public bool DoRestart(){
        do {
            Console.Write($"Do you want to restart ? [Y]es or [N]o : ");
            string val = Console.ReadLine().ToUpper();
            if (val.Equals("N")) return false;
            if (val.Equals("Y")) {Initfield();return true;}
            Console.WriteLine("error, only Y or N");
        } while (true);
    }
}
