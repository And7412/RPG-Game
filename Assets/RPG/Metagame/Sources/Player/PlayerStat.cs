using System;

namespace RPG.Metagame.Heroes.Player
{
    public class PlayerStat : IStat
    {
        public int MaxValue { get;}
        public int Value { get; private set; }
        
        public PlayerStat(int maxValue)
        {
            MaxValue = maxValue;
        }

        public void Set(int value)
        {
            if (value < 0 || value > MaxValue)
                throw new ArgumentException();

            Value = value;
        }

        public void Increase(int value)
        {
            Value += value;
        }

        public void Decrease(int value)
        {
            Value -= value;
        }
    }
}

