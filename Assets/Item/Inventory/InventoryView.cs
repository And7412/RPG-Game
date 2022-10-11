using Core.Patterns.Factory;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.InventorySystem
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private ItemInventoryView _cellTemplate;
        [SerializeField] private FactoryBehaviour _factoryBehaviour;

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
            var cellView = _factoryBehaviour.Create(_cellTemplate);
            _cellViews.Add(cellView);
        }

        public void ShowWeapon()
        {
            ShowItems(_inventory.Weapons);
        }

        public void ShowArmor()
        {
            ShowItems(_inventory.Armors);
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
