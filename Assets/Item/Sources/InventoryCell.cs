using System;
using RPG.Item;
using UnityEngine;

namespace RPG.InventorySystem
{
    [Serializable]
    public class InventoryCell
    {
        [SerializeField] private ItemConfig _config;
        [SerializeField] private int _amount;

        public ItemConfig Config => _config;
        public int Amount => _amount;

        private int capacity => _config.GetCapacity();

        public InventoryCell(ItemConfig config, int amount)
        {
            _config = config;
            _amount = amount;
        }

        public bool TryAdd(int amount, out int difference)
        {
            int tmp = _amount + amount;

            bool success = tmp <= capacity;
            if (success)
            {
                _amount = tmp;
                difference = 0;
                return true;
            }

            difference = tmp - capacity;
            _amount = capacity;
            return false;
        }

        public bool Remove(int amount, out int difference)
        {
            _amount -= amount;
            int tmp = _amount - amount;

            if (tmp < 1)
            {
                difference = Mathf.Abs(tmp);
                _amount = 0;
                return true;
            }

            _amount = tmp;
            difference = 0;
            return false;
        }
    }
}

