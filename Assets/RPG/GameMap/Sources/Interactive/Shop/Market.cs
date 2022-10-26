using System.Collections;
using System.Collections.Generic;
using RPG.Metagame.Player;
using UnityEngine;

namespace RPG.GameMap.Shop
{
    public class Market : MonoBehaviour
    {
        [SerializeField] private Shop[] _shops;

        public void Initialize(IPlayerTrade player)
        {
            foreach (var shop in _shops)
            {
                shop.Initialize(player);
            }
        }
    }
}

