using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Patterns.ServiceLocator
{
    public class ServiceLocator<T> : IServiceLocator<T>
    {
        public T Service { get; set; }

        private static ServiceLocator<T> _locator;

        public static IServiceLocator<T> Instance
        {
            get
            {
                if (_locator == null)
                {
                    _locator = new ServiceLocator<T>();
                }

                return _locator;
            }
        }
    }

    public interface IServiceLocator<T>
    {
        T Service { get; }
    }
}



