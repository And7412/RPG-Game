using System;
using System.Collections;
using System.Collections.Generic;
using RPG.PlayerSystem;
using UnityEngine;

namespace RPG.GameMap
{
    public class GameMap : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;

        private void Awake()
        {

            var player = new Player(_playerConfig);
            //player.SetMaxHP();

            player.Hit();
        }
    }
}

