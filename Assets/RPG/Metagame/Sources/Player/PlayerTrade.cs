using System.Collections;
using System.Collections.Generic;
using RPG.Metagame.InventorySystem;
using UnityEngine;

namespace RPG.Metagame.Player
{
    public class PlayerTrade
    {
        private Money _money;
        private Inventory _inventory;

        public PlayerTrade(Money money, Inventory inventory)
        {

        }

        public ItemTransactionResult RunTransaction(ItemTransaction transaction)
        {
            //TODO
            return ItemTransactionResult.None;
        }
    }
}

