using System;

public class PlayerLevel 
{
    public int XpVaule { get; private set; }
    public int Level { get; private set; }
    private int Ratio = 100;
    private int XpToNextLevel;

    public PlayerLevel(int XP, int LV,int ration)
    {
        if (XP < 0 || LV < 0|| Ratio <= 0)
        {
            throw new ArgumentException();
        }
        XpVaule = XP;
        Level = LV;
        Ratio = ration;
    }
    public void IncreaseXp(int value)
    {
        XpVaule += value;
        IncreaseLevel();
    }
    public void IncreaseLevel()
    {
        XpToNextLevel = Level * Ratio;
        if (XpVaule >= XpToNextLevel)
        {
            XpVaule -= XpToNextLevel;
            Level++;
        }
        
    }

}
