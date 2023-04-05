using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Saves
{
    public class PrefsJsonProvider
    {
        public static void Save<T>(T value) where T : new()
        {
            var json = JsonUtility.ToJson(value);
            PlayerPrefs.SetString(typeof(T).Name, json);
        }

        public static void SaveByName<T>(T value, string name) where T : new()
        {
            var saveName = GetSaveName(typeof(T), name);
            var json = JsonUtility.ToJson(value);
            PlayerPrefs.SetString(saveName, json);
        }

        public static T Load<T>() where T : new()
        {
            var key = typeof(T).Name;
            var hasKey = CheckKey(key);

            if (!hasKey)
                return new T();

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

        public static T LoadByName<T>(string name) where T : new()
        {
            var key = GetSaveName(typeof(T), name);
            var hasKey = CheckKey(key);

            if (!hasKey)
                return new T();

            var saveName = GetSaveName(typeof(T), name);
            var data = PlayerPrefs.GetString(saveName);
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

        public static void DeleteSave<T>()
        {
            var key = typeof(T).Name;
            var hasKey = CheckKey(key);
            
            if (!hasKey)
                throw new ArgumentException($"Preferences not contains key {key}");

            PlayerPrefs.DeleteKey(key);
        }

        public static void DeleteSaveByName<T>(string name)
        {
            var key = GetSaveName(typeof(T), name);
            var hasKey = CheckKey(key);
            
            if (!hasKey)
                throw new ArgumentException($"Preferences not contains key {key}");

            PlayerPrefs.DeleteKey(key);
        }

        public static string GetSaveName(Type saveType, string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name is not set");

            return saveType.Name + name;
        }

        private static bool CheckKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }
    }
}

