using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Patterns.Pool
{
    public class Pool<T> where T: IPoolable
    {
        public bool HasItems => _items.Count != 0;
        private List<T> _items;

        public Pool()
        {
            _items = new List<T>();
        }

        public T Pop()
        {
            foreach (var obj in _items)
            {
                if (obj.Active == false)
                {
                    obj.SetActive(true);
                    _items.Remove(obj);
                    return obj;
                }
            }
            throw new InvalidOperationException("no items in pool");
        }

        public void Push(T obj)
        {
            obj.SetActive(false);
            _items.Add(obj);
        }
    }
}
