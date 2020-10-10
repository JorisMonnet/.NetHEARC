using System;

public class Player
{
	public Player(char sign)	{
		this.sign = sign;
	}
    public override string ToString() {
        return sign.ToString();
    }
    private char sign { get; set; }=' ';
	public int nbVictory { get; set; } = 0;
}
