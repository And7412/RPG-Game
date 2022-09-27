using System.Collections;
using System.Collections.Generic;
using RPG.Item;
using UnityEngine;

namespace RPG.InventorySystem
{
    public class InventoryItem
    {
        public ItemConfig Config { get; }
        public int Amount { get; private set; }

        public InventoryItem(ItemConfig config, int amount)
        {
            Config = config;
            Amount = amount;
        }

        public void Add(int amount)
        {
            Amount += amount;
        }

        public void Remove(int amount)
        {
            Amount -= amount;
        }
    }
}

