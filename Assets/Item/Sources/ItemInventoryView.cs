using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Item;
using UnityEngine;

namespace RPG.InventorySystem
{
    public class ItemInventoryView : MonoBehaviour
    {
        public event Action<> 
        private Item _config;

        public void SetConfig(ItemConfig config)
        {
            _config = config;
        }
    }
}

