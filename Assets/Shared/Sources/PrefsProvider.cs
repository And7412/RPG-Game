using UnityEngine;

namespace RPG.Shared
{
    public class PrefsProvider
    {
        private const string playerHealthKey = "PlayerHealth";

        public static void SavePlayerHealth(int value)
        {
            PlayerPrefs.SetInt(playerHealthKey, value);
            PlayerPrefs.Save();
        }

        public static int LoadPlayerHealth()
        {
            var result = PlayerPrefs.GetInt(playerHealthKey);
            return result;
        }
    }
}

