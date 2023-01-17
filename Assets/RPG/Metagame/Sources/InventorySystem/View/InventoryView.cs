using Core.Patterns.Factory;
using System.Collections.Generic;
using UnityEngine;
using Core.Patterns.Pool;

namespace RPG.Metagame.InventorySystem.View
{
    public class InventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField] private InventoryItemView _cellTemplate;
        [SerializeField] private FactoryBehaviour _factoryBehaviour;
        [SerializeField] private InventoryButtons _buttons;

        private Pool<InventoryItemView> _inactiveCells;

        private IInventoryRead _inventory;
        private List<InventoryItemView> _activeCells;

        public void Initialize(IInventoryRead inventory)
        {
            _inventory = inventory;
            _activeCells = new List<InventoryItemView>();
            _inactiveCells = new Pool<InventoryItemView>();
            _buttons.Initialize(this, InventorySlotType.Weapon);
        }

        public void Show()
        {
            ShowWeapon();
        }

        private void CreateInactiveCellView()
        {
            var cellView = _factoryBehaviour.Create(_cellTemplate);
            _inactiveCells.Push(cellView);
        }

        public void ShowWeapon() => ShowItems(_inventory.WeaponSection);
        public void ShowArmor() => ShowItems(_inventory.ArmorSection);
        public void ShowConsumables() => ShowItems(_inventory.ConsumeSection);
        public void ShowMisc() => ShowItems(_inventory.MiscSection);
        public void ShowQuest() => ShowItems(_inventory.QuestSection);


        private void ShowItems(IInventorySectionRead inventorySection)
        {
            var amount = inventorySection.Cells.Count;
            var amountDiff = amount - _activeCells.Count;

            if (amountDiff > 0)
            {
                AddCells(amountDiff);
            }
            else
            {
                RemoveCells(Mathf.Abs(amountDiff));
            }

            int viewNum = 0;

            foreach (var cell in inventorySection.Cells)
            {
                _activeCells[viewNum].SetCell(cell);
                viewNum++;
            }
        }

        private void AddCells(int amountDiff)
        {
            for (int i = 0; i < amountDiff; i++)
            {
                if (!_inactiveCells.HasItems)
                    CreateInactiveCellView();

                _activeCells.Add(_inactiveCells.Pop());
            }
        }

        private void RemoveCells(int amountDiff)
        {
            for (int i = 0; i < amountDiff; i++)
            {
                var cellView = _activeCells[0];
                _activeCells.Remove(cellView);
                _inactiveCells.Push(cellView);
            }
        }
    }

    public interface IInventoryView
    {
        void ShowWeapon();
        void ShowArmor();
        void ShowConsumables();
        void ShowMisc();
        void ShowQuest();
    }
}
