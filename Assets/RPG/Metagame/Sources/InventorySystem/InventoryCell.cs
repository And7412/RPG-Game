﻿using System;
using RPG.Metagame.InventorySystem;
using UnityEngine;

namespace RPG.Metagame.InventorySystem
{
    [Serializable]
    public class InventoryCell
    {
        [SerializeField] private ItemConfig _config;
        [SerializeField] private int _amount;

        public ItemConfig Config => _config;
        public int Amount => _amount;

        private int capacity => _config.GetCapacity();

        public InventoryCell() { }

        public InventoryCell(ItemConfig config)
        {
            _config = config;
        }

        public bool TryAdd()
        {
            var resultAmount = _amount + 1;
            var canAdd =  resultAmount <= capacity;

            if (canAdd)
                return false;

            _amount = resultAmount;
            return true;
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

