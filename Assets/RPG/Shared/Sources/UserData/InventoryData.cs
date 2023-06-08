using System;
using System.Collections.Generic;
using RPG.Metagame.InventorySystem;

namespace RPG.Shared.UserData
{
    [Serializable]
    public class InventoryData 
    {
        public int Money { get; set; }
        public InventoryItemCountData[] InventoryItems { get; set; } = new InventoryItemCountData[0];

        public InventoryData(IInventoryRead inventoryRead)
        {
            var items = new List<InventoryItemCountData>();
            //TODO load data from inventory
            AddCellsToItemsList(inventoryRead.WeaponSection.Cells, items);
            AddCellsToItemsList(inventoryRead.ArmorSection.Cells, items);
            AddCellsToItemsList(inventoryRead.MiscSection.Cells, items);
            AddCellsToItemsList(inventoryRead.ConsumeSection.Cells, items);
            AddCellsToItemsList(inventoryRead.QuestSection.Cells, items);

            Money = inventoryRead.Money.Value.Value;
        }

        private void AddCellsToItemsList(IEnumerable<IInventoryCell> cells, List<InventoryItemCountData> list)
        {
            foreach (var cell in cells)
            {
                var itemData = new InventoryItemCountData(cell);
                list.Add(itemData);
            }
        }
        
        public InventoryItemCountData[] GetItemsForCell(InventorySlotType slotType)
        {
            
        }
    }
}
