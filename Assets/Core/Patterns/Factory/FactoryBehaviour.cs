using UnityEngine;

namespace Core.Patterns.Factory
{
    public class FactoryBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform _root;

        public T Create<T>(T template) where T : MonoBehaviour
        {
            var item = Instantiate(template, _root);
            return item;
        }
    }
}

