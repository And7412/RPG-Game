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

        public void Show()
        {
            ShowWeapon();
        }

        public void AddCellView()
        {
            //_cellViews.Add(newView)
        }

        public void ShowWeapon()
        {
            ShowItems(_inventory.Weapons);
        }

        private void ShowItems(IReadOnlyList<InventoryCell> cells)
        {
            var amount = cells.Count;
            var amountDiff = _cellViews.Count - amount;

            for (int i = 0; i < amountDiff; i++)
            {
                AddCellView();
            }

            int viewNum = 0;

            foreach (var cell in cells)
            {
                _cellViews[viewNum].SetCell(cell);
                viewNum++;
            }
        }
    }
}
