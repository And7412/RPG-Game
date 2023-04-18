using System.Collections;
using System.Collections.Generic;
using Core.Patterns.ServiceLocator;
using RPG.Metagame.Player;
using RPG.Shared.UserData;
using UnityEngine;

namespace RPG.GameMap
{
    public class GameMapDataSaver : MonoBehaviour
    {
        private Player _player;
        private UserSaveBuffer _buffer;
        private UserSaveSystem _saveSystem;
        
        public void InitializeBuffer(Player player)
        {
            _player = player;
            _saveSystem = ServiceLocator.Instance.GetService<UserSaveSystem>();
            _buffer = new GameMapUserSaveBuffer(_saveSystem.CurrentSave, _player);
        }
        
        public void SaveData()
        {
            _saveSystem.RewriteSaveFromBuffer(_buffer);
        }
    }
}

