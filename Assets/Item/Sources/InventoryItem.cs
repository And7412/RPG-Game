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

        public int Add(int amount)
        {
            int tmp = Amount + amount;

            if (tmp > _capacity)
            {
                int difference = tmp - _capacity;
                Amount = _capacity;
                return difference;
            }
            else
            {
                Amount = tmp;
                return 0;
            }

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
            else
            {
                Amount = tmp;
                return 0;
            }
        }
    }
}

