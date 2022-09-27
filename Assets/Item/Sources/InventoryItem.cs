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
        private readonly int _capacity;

        public InventoryItem(ItemConfig config, int amount)
        {
            Config = config;
            Amount = amount;
            _capacity = Config.GetCapacity();
        }

        public bool TryAdd(int amount, out int difference)
        {
            int tmp = Amount + amount;

            bool success = tmp <= _capacity;
            if (success)
            {
                Amount = tmp;
                difference = 0;
                return true;
            }

            difference = tmp - _capacity;
            Amount = _capacity;
            return false;
        }

        public int Remove(int amount)
        {
            Amount -= amount;
            int tmp = Amount - amount;

            if (tmp < 1)
            {
                int difference = Mathf.Abs(tmp);
                Amount = 0;
                return difference;
            }

            Amount = tmp;
            return 0;
        }
    }
}

