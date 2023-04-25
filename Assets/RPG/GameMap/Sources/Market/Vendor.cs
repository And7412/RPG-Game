using System.Collections;
using System.Collections.Generic;
using RPG.Metagame.InventorySystem;
using RPG.Shared.UserData;
using UnityEngine;

namespace RPG.GameMap.Shop
{
    public class Vendor : ISavable<VendorSave>
    {
        private Money _money;
        private Inventory _inventory;

        public Vendor(VendorConfig config)
        {
            _money = new Money(config.DefaultMoneyValue);
            _inventory = new Inventory();
        }
        public VendorSave GetForSave()
        {
            var VendorSave = new VendorSave();
            VendorSave.Money = _money.Value;
            List<InventoryItemCountData> inventoryItems = new List<InventoryItemCountData>();
            foreach(var section in _inventory.Sections)
            {
                foreach(var j in section.Cells)
                {
                    var i = new InventoryItemCountData();
                    i.Id = j.Config.Id;
                    i.Count = j.Amount;
                    inventoryItems.Add(i);
                }
            }
            VendorSave.Inventory = inventoryItems.ToArray();
            VendorSave.Name = this.ToString();
            return new VendorSave();
        }
    }
}


