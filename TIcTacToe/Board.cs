using System;
using static System.Console;

public class Board : ITerminable
{
	private Player currentPlayer,nextPlayer;
    private Player[,] field;
    public Board(Player p1,Player p2) {
        currentPlayer = p1;
        nextPlayer = p2;
        field = new Player[3,3];
	}
    public bool IsPossible(int x,int y){
        try{
            return field[x,y] == null;
        } catch { 
            return false; 
        }
    }
    public bool InsertMove(int x,int y) {
        if(IsPossible(x,y)) {
            field[x,y] = currentPlayer;
            (currentPlayer, nextPlayer) = (nextPlayer, currentPlayer);
            return true;
        } else {
            WriteLine("Move not valid !");
            return false;
        }
        
    }
    
    public bool IsFinished(){
        int col = 0, row = 0, diag = 0, antidiag = 0;
        Player pc, pr;
        for(int x = 0;x < 2;x++) {
            if(field[0,0] != null && field[0,0] == field[x,x]) diag++;

            for(int y = 0;y < 2;y++) {
                if(field[x,0] != null && field[x,0] == field[x,y]) row++; 
                if(field[0,x] != null && field[0,x] == field[y,x]) col++; 
                if(x + y == 1 && field[0,2] != null && field[0,2] == field[x,y]) antidiag++; 
            }
            if(col >= 2 || row >= 2 || diag >= 2 || antidiag >= 2) {
                nextPlayer.nbVictory++;
                WriteLine($"Player {nextPlayer} won ! Victories : Player {nextPlayer}:{nextPlayer.nbVictory}\tPlayer {currentPlayer}:{currentPlayer.nbVictory}");
                return true;
            }
            col = 0; row = 0;
        }
        if (IsCompleted()){
            Console.WriteLine($"Draw ! Victories : Player{currentPlayer}:{currentPlayer.nbVictory}\tPlayer {nextPlayer}:{nextPlayer.nbVictory}");
            return true;
        }
        return false;
    }
    public bool IsCompleted(){
        for(int i = 0;i < 3;i++) {
            for(int j=0;j<3;j++){
                if(field[i,j] == null) return false;
            }
        }
        return true;
    }
    public bool DoRestart(){
        do {
            Console.Write($"Do you want to restart ? [Y]es or [N]o : ");
            string val = Console.ReadLine().ToUpper();
            if (val.Equals("N")) return false;
            if (val.Equals("Y")) {field=new Player[3,3];return true;}
            Console.WriteLine("error, only Y or N");
        } while (true);
    }
    internal Tuple<int,int> NextMove() {
        string val;
        do {
            Write($"Player {currentPlayer} please enter x,y : ");
            val = ReadLine();
            try {
                if(val.Contains(",")) {
                    string[] nums = val.Split(',');
                    return Tuple.Create(int.Parse(nums[1]),int.Parse(nums[0]));
                }
                else throw new Exception("Wrong coordinates format");
            } catch(Exception e) {WriteLine(e.Message); }
        } while(true);
    }
    public Player this[int x,int y] {
        get { return field[x,y]; }
    }
}
