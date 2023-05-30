using System;
using Core.Patterns.EventValue;

namespace RPG.Metagame.InventorySystem
{
    public class Money
    {
        public EventValue<int> Value { get; private set; } = new EventValue<int>();

        public Money(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }

            Value.Value = value;
        }

        public void Increase(int value)
        {
            if (value < 0)
                throw new ArgumentException("value is lower then zero");

            Value.Value += value;
        }

        public bool TryDecrease(int value)
        {
            if (Value.Value < value)
            {
                return false;
            }
            
            Value.Value -= value;
            return true;
        }

        public bool IsEnough(int value)
        {
            return Value.Value >= value;
        }
    }
}
