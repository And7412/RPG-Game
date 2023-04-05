using System;
using System.Linq;

namespace Core.Saves
{
    public class PrefsVault
    {
        public static void AddSave(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Trying to add wrong name");

            var keysVault = PrefsJsonProvider.Load<PreferencesKeysVault>();
            var keys = keysVault.Keys.ToList();

            if (keys.Contains(name))
                return;

            keys.Add(name);
            keysVault.Keys = keys.ToArray();
            PrefsJsonProvider.Save(keysVault);
        }

        public static void RemoveSave(string name)
        {
            var keysVault = PrefsJsonProvider.Load<PreferencesKeysVault>();
            var keys = keysVault.Keys.ToList();

            if (!keys.Contains(name))
                throw new ArgumentException($"Vault not contains save named {name}");

            keys.Remove(name);
            keysVault.Keys = keys.ToArray();
            PrefsJsonProvider.Save(keysVault);
        }

        public string[] GetAllNames()
        {
            var keysVault = PrefsJsonProvider.Load<PreferencesKeysVault>();
            return keysVault.Keys;
        }
    }

    [Serializable]
    public class PreferencesKeysVault
    {
        public string[] Keys = new string[0];
    }
}

