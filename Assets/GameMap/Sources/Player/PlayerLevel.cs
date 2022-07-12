using System;

public class PlayerLevel 
{
    public int Xp { get; private set; }
    public int Level { get; private set; }
    public int XpToNextLevel { get; private set; }

    private readonly int _ratio = 100;

    public PlayerLevel(int xp, int lvl, int ratio)
    {
        if (xp < 0 || lvl < 0|| _ratio <= 0)
        {
            throw new ArgumentException();
        }

        Xp = xp;
        Level = lvl;
        _ratio = ratio;
        XpToNextLevel = Level * _ratio;
    }

    public void IncreaseXp(int value)
    {
        if (value < 0)
            throw new ArgumentException("xp is lower then zero");

        Xp += value;
        CheckXp();
    }

    private void CheckXp()
    {
        if (Xp < XpToNextLevel)
            return;

        var diff = Xp - XpToNextLevel;
        IncreaseLvl();
        Xp = diff;
    }

    private void IncreaseLvl()
    {
        Level++;
        XpToNextLevel = Level * _ratio;
    }
}
