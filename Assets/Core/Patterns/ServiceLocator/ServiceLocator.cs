using System;

namespace Core.Patterns.ServiceLocator
{
    public class ServiceLocator : IServiceLocator
    {
        private static ServiceLocator _locator;
        private TypeDictionary _dict = new TypeDictionary();

        public static ServiceLocator Initialize()
        {
            if (_locator != null)
                throw new InvalidOperationException("Cant overwrite service locator");

            _locator = new ServiceLocator();
            return _locator;
        }

        public static IServiceLocator Instance
        {
            get
            {
                if (_locator == null)
                    throw new InvalidOperationException("Locator is not initialized");

                return _locator;
            }
        }

        public void Register<T>(T obj) where T: class
        {
            _dict.Add(obj);
        }

        public void UnRegister<T>(T obj) where T : class
        {
            _dict.Remove<T>();
        }

        public T GetService<T>() where T : class
        {
            return _dict.Get<T>();
        }
    }

    public interface IServiceLocator
    {
        T GetService<T>() where T : class;
    }
}



