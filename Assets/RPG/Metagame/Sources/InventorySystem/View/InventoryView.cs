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

        private Pool<InventoryItemView> pool;

        private IInventoryRead _inventory;
        private List<InventoryItemView> _cellViews;

        public void Initialize(IInventoryRead inventory)
        {
            _inventory = inventory;
            _cellViews = new List<InventoryItemView>();
            _buttons.Initialize(this);
            pool = new Pool<InventoryItemView>();
        }

        public void Show()
        {
            ShowWeapon();
        }

        public void AddCellView()
        {
            var cellView = _factoryBehaviour.Create(_cellTemplate);
            _cellViews.Add(cellView);
            pool.AddedPool(cellView);
        }

        public void ShowWeapon() => ShowItems(_inventory.WeaponSection);
        public void ShowArmor() => ShowItems(_inventory.ArmorSection);
        public void ShowConsumables() => ShowItems(_inventory.ConsumeSection);
        public void ShowMisc() => ShowItems(_inventory.MiscSection);
        public void ShowQuest() => ShowItems(_inventory.QuestSection);


        private void ShowItems(IInventorySectionRead inventorySection)
        {
            var amount = inventorySection.Cells.Count;
            var amountDiff = amount - _cellViews.Count;

            for (int i = 0; i < amountDiff; i++)
            {
                AddCellView();
            }

            for (int i = 0; i > amountDiff; i--)
            {
                int x = _cellViews.Count + amountDiff;
                _cellViews[x].SetActive(false);
                amountDiff++;
            }

            int viewNum = 0;

            foreach (var cell in inventorySection.Cells)
            {
                _cellViews[viewNum].SetCell(cell);
                viewNum++;
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
