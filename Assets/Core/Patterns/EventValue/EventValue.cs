using System;

namespace Core.Patterns.EventValue
{
    public class EventValue<T>
    {
        public T Value
        {
            get
            {
                if (_value == null)
                    return default;
                
                return _value;
            }
            set
            {
                _value = value;
                Changed?.Invoke(_value);
            }
        }

        private T _value;
        public event Action<T> Changed;

        public EventValue()
        {
            _value = default;
        }
    }
}

