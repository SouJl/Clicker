using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClickerRoot.Scripts.Utils
{
    public class EventBus : MonoBehaviour
    {
        public static EventBus Instance = null;

        private void Awake()
        {
            if (Instance == null)
            { 
                Instance = this; 
            }
            else if (Instance == this)
            { 
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }


        private readonly Dictionary<string, List<object>> _eventCallBacks
            = new Dictionary<string, List<object>>();

        public void Subscrive<T>(Action<T> callBack)
        {
            string key = typeof(T).Name;
            if (_eventCallBacks.ContainsKey(key))
            {
                _eventCallBacks[key].Add(callBack);
            }
            else 
            {
                _eventCallBacks.Add(key, new List<object>() { callBack });
            }
        }

        public void Unsubscribe<T>(Action<T> callBack) 
        {
            string key = typeof(T).Name;
            if (_eventCallBacks.ContainsKey(key))
            {
                _eventCallBacks[key].Remove(callBack);
            }
            else
            {
                Debug.LogErrorFormat($"Trying to unsubscribe not presented callback : {callBack}");
            }
        }

        public void Invoke<T>(T eventValue)
        {
            string key = typeof(T).Name;
            if (_eventCallBacks.ContainsKey(key)) 
            {
                foreach(var @object in _eventCallBacks[key])
                {
                    var callBaclk = @object as Action<T>;
                    callBaclk?.Invoke(eventValue);
                }
            }
        }
    }
}
