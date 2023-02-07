using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Core.Patterns.ServiceLocator
{
    public class TypeDictionary
    {
        private Dictionary<Type, Object> _dict;

        public TypeDictionary()
        {
            _dict = new Dictionary<Type, Object>();
        }

        public void Add<T>(T obj) where T: Object
        {
            var type = typeof(T);

            if (_dict.ContainsKey(type))
                throw new ArgumentException($"Dictionary already contains type {type.Name}");

            _dict.Add(type, obj);
        }

        public void Remove<T>() where T : Object
        {
            var type = typeof(T);

            if (!_dict.ContainsKey(type))
                throw new ArgumentException($"Dictionary is not contain type {type.Name}");

            _dict.Remove(type);
        }

        public T Get<T>() where T: Object
        {
            var type = typeof(T);

            if (!_dict.ContainsKey(type))
                throw new ArgumentException($"Dictionary is not contain type {type.Name}");

            var result = _dict[type];
            return result as T;
        }
    }
}

