using System.Collections.Generic;
using RPG.Metagame.InventorySystem;
using RPG.Shared.UserData;

namespace RPG.GameMap.MarketSystem
{
    public class Vendor : ISavable<VendorSave>
    {
        private Money _money;
        private Inventory _inventory;
        
        public string Name { get; }
        public string Id { get; }
        public int Money => _money.Value;
        public IInventoryRead Inventory => _inventory;

        public Vendor(VendorConfig config)
        {
            _money = new Money(config.DefaultMoneyValue);
            _inventory = new Inventory();
            Name = config.Name;
            Id = config.Id;
        }
        
        public VendorSave GetForSave()
        {
            var vendorSave = new VendorSave();
            vendorSave.Money = _money.Value;
            List<InventoryItemCountData> inventoryItems = new List<InventoryItemCountData>();
            
            foreach(var section in _inventory.Sections)
            {
                foreach(var cell in section.Cells)
                {
                    var data = new InventoryItemCountData();
                    data.Id = cell.Config.Id;
                    data.Count = cell.Amount;
                    inventoryItems.Add(data);
                }
            }
            vendorSave.Inventory = inventoryItems.ToArray();
            vendorSave.Name = Name;
            return new VendorSave();
        }
    }
}


