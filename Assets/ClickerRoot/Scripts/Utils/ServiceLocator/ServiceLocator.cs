using System.Collections.Generic;
using System;
using UnityEngine;

namespace ClickerRoot.Scripts.Utils.ServiceLocator
{
    public class ServiceLocator
    {
        private readonly Dictionary<string, IService> _services = new Dictionary<string, IService>();

        public static ServiceLocator Current { get; private set; }

        private ServiceLocator() { }

        public static void Initialize()
        {
            Current = new ServiceLocator();
        }


        public T Get<T>() where T : IService
        {
            string key = typeof(T).Name;
            if (!_services.ContainsKey(key))
            {
                Debug.LogError($"{key} not registered with {GetType().Name}");
                throw new InvalidOperationException();
            }

            return (T)_services[key];
        }


        public void Register<T>(T service) where T : IService
        {
            string key = typeof(T).Name;
            if (_services.ContainsKey(key))
            {
                Debug.LogError($"Trying to register service {key} which is already registered!");
                return;
            }

            _services.Add(key, service);
        }


        public void Unregister<T>() where T : IService
        {
            string key = typeof(T).Name;
            if (!_services.ContainsKey(key))
            {
                Debug.LogError($"Trying to unregister service of type {key} which is not registered!");
                return;
            }

            _services.Remove(key);
        }

    }
}
