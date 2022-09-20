using System.Collections;
using System.Collections.Generic;
using RPG.InventorySystem;
using RPG.Item;
using UnityEngine;

namespace RPG.PlayerSystem
{
    public class PlayerTrade
    {
        private PlayerMoney _money;
        private Inventory _inventory;

        public PlayerTrade(PlayerMoney money, Inventory inventory)
        {

        }

        public ItemTransactionResult RunTransaction(ItemTransaction transaction)
        {
            //TODO
            return ItemTransactionResult.None;
        }
    }
}

