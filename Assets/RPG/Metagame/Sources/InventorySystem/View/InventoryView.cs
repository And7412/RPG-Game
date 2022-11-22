﻿using Core.Patterns.Factory;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Metagame.InventorySystem.View
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private InventoryItemView _cellTemplate;
        [SerializeField] private FactoryBehaviour _factoryBehaviour;

        private IInventoryRead _inventory;
        private List<InventoryItemView> _cellViews;

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
            ShowItems(_inventory.WeaponSection);
        }

        public void ShowArmor()
        {
            ShowItems(_inventory.ArmorSection);
        }

        private void ShowItems(IInventorySectionRead inventorySection)
        {
            var amount = inventorySection.Cells.Count;
            var amountDiff = _cellViews.Count - amount;

            for (int i = 0; i < amountDiff; i++)
            {
                AddCellView();
            }

            int viewNum = 0;

            foreach (var cell in inventorySection.Cells)
            {
                _cellViews[viewNum].SetCell(cell);
                viewNum++;
            }
        }
    }
}
