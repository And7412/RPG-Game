using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Shared.UserData
{
    public class UserSaveBuffer
    {
        private readonly UserSaveSystem _saveSystem;
        private readonly UserSave _save;

        public UserSaveBuffer(UserSaveSystem saveSystem, UserSave save)
        {
            _saveSystem = saveSystem;
            _save = save;
        }

        public void SaveLevel(int xp, int lv)
        {
            _save.PlayerHeroData.LevelData.Xp = xp;
            _save.PlayerHeroData.LevelData.Level = lv;
        }
    }
}
