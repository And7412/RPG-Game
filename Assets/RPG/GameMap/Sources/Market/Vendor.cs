using System.Collections;
using System.Collections.Generic;
using RPG.Metagame.InventorySystem;
using UnityEngine;

namespace RPG.GameMap.Shop
{
    public class Vendor
    {
        private Money _money;
        private Inventory _inventory;

        public Vendor(VendorConfig config)
        {
            _money = new Money(config.DefaultMoneyValue);
            _inventory = new Inventory();
        }
    }
}


