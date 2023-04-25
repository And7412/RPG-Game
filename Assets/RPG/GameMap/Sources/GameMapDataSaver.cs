using System.Collections;
using System.Collections.Generic;
using Core.Patterns.ServiceLocator;
using RPG.GameMap.MarketSystem;
using RPG.Metagame.Player;
using RPG.Shared.UserData;
using UnityEngine;

namespace RPG.GameMap
{
    public class GameMapDataSaver : MonoBehaviour
    {
        private UserSaveBuffer _buffer;
        private UserSaveSystem _saveSystem;

        public void InitializeBuffer(Player player,Market market)
        {
            _saveSystem = ServiceLocator.Instance.GetService<UserSaveSystem>();
            _buffer = new GameMapUserSaveBuffer(_saveSystem.CurrentSave, player,market);
        }
        
        public void SaveData()
        {
            _saveSystem.RewriteSaveFromBuffer(_buffer);
        }
    }
}

