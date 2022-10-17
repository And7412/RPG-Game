using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using RPG.InventorySystem;
namespace RPG.Vendors
{
    public class Vendor : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Inventory _inventory;

        public event Action<Inventory> GiveInventoy;

        private void Awake()
        {
            _button.onClick.AddListener(OnClick);
        }
        private void OnClick()
        {
            GiveInventoy?.Invoke(_inventory);
        }
    }

}
