using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.InventorySystem
{
    public class InventoryView : MonoBehaviour 
    {
        private IInventoryRead _inventory;
        private List<ItemInventoryView> _cellViews;
        public void Initialize(IInventoryRead inventory)
        {
            _inventory = inventory;
        }
        public ItemInventoryView AddCell()
        {
            return null;
        }
        public void Weapon()
        {
            foreach (var cell in _inventory.Weapons)
            {
                cell.
            }
        }
    }
}
