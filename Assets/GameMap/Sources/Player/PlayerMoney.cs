using System;

namespace RPG.PlayerSystem
{
    public class PlayerMoney
    {
        public int Value { get; private set; }

        public PlayerMoney(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            Value = value;
        }

        public void Increase(int value)
        {
            Value += value;
        }

        public bool Decrease(int value)
        {
            if (Value < value)
            {
                return false;
            }
            Value -= value;
            return true;
        }
    }
}
