using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.PlayerSystem
{
    public class CheckMissingCoins
    {
        private int _money;
        public void Initialization(Player player)
        {
            var _player = player;
            _money = _player.Money.Value;

        }
        public bool TryMissingCoins(int Price)
        {
            var I = _money - Price;
            if (I >= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
