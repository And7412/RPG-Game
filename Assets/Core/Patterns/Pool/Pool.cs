using Core.Patterns.Pool;
using System;
using System.Collections.Generic;

namespace RPG.Metagame.InventorySystem
{
    public class Pool<T> where T: IPoolable
    {
        private List<T> _items;

        public Pool(T[] item)
        {
            foreach (var obj in item)
            {
                _items.Add(obj);
            }
            _items = new List<T>(item);
        }
        public Pool()
        {
            _items = new List<T>();
        }

        public void AddedPool(T Obj)
        {
            _items.Add(Obj);

        }

        public T Pop()
        {
            foreach (var obj in _items)
            {
                if (obj.Active == false)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }
            throw new InvalidOperationException("no items in pool");
        }

        public void Push(T obj)
        {
            obj.SetActive(false);
        }
    }
}
