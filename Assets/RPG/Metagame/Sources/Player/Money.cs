using System;

namespace RPG.Metagame.Player
{
    public class Money
    {
        public int Value { get; private set; }
        public event Action<int> MoneyChanged;

        public Money(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }

            Value = value;
        }

        public void Increase(int value)
        {
            if (value < 0)
                throw new ArgumentException("value is lower then zero");

            Value += value;
            MoneyChanged?.Invoke(Value);
        }

        public bool TryDecrease(int value)
        {
            if (Value < value)
            {
                return false;
            }
            
            Value -= value;
            MoneyChanged?.Invoke(Value);
            return true;
        }

        public bool IsEnough(int value)
        {
            return Value >= value;
        }
    }
}
