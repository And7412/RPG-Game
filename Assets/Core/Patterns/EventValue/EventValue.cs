using System;

namespace Core.Patterns.EventValue
{
    public class EventValue<T>
    {
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                Changed?.Invoke(_value);
            }
        }

        private T _value;
        public event Action<T> Changed;
    }
}

