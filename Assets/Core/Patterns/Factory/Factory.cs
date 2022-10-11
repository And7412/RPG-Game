using UnityEngine;

namespace Core.Patterns.Factory
{
    public class Factory<T,V> where T: MonoBehaviour, IInitializable<V>
    {
        private readonly T _template;
        private readonly FactoryBehaviour _factoryBehaviour;

        public Factory(T template, FactoryBehaviour factoryBehaviour)
        {
            _template = template;
            _factoryBehaviour = factoryBehaviour;
        }

        public T Create(V args)
        {
            var item = _factoryBehaviour.Create(_template);
            item.Initialize(args);
            return item;
        }
    }
}
