﻿using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RPG.Shared
{
    public class PrefsJsonProvider
    {
        public static T Load<T>() where T: new()
        {
            var data = PlayerPrefs.GetString(typeof(T).Name);
            T result;

            if (string.IsNullOrEmpty(data))
            {
                result = new T();
            }
            else
            {
                result = JsonUtility.FromJson<T>(data);
            }

            return result;
        }

        public static void Save<T>(T value) where T : new()
        {
            var data = JsonUtility.ToJson(value);
            PlayerPrefs.SetString(typeof(T).Name, data);
        }
    }
}

