using System;
using System.Collections;
using System.Collections.Generic;
using RPG.PlayerSystem;
using UnityEngine;
using RPG.GameMap.TavernSystem;

namespace RPG.GameMap
{
    public class GameMap : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Tavern _tavern;

        private void Awake()
        {

            var player = new Player(_playerConfig);
            //player.SetMaxHP();
            _tavern.Initialize(player);

            
        }
    }
}

