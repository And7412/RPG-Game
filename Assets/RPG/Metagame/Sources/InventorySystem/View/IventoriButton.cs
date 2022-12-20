using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.Metagame.InventorySystem.View;

namespace RPG.Metagame.InventorySystem
{
    public class IventoriButton : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventory;

        [SerializeField] private Button _buttonMisc;
        [SerializeField] private Button _buttonArmor;
        [SerializeField] private Button _buttonWeapon;
        [SerializeField] private Button _buttonConsume;
        [SerializeField] private Button _buttonQuest;

        private void Awake()
        {
            _buttonWeapon.onClick.AddListener(onClictButtonWeapon);
            _buttonArmor.onClick.AddListener(onClictButtonArmor);
            _buttonConsume.onClick.AddListener(onClictButtonConsume);
            _buttonQuest.onClick.AddListener(onClictButtonQuest);
            _buttonMisc.onClick.AddListener(onClictButtonMisc);
        }
        public void onClictButtonQuest()
        {
            _inventory.ShowQuest();
        }
        public void onClictButtonMisc()
        {
            _inventory.ShowMisc();
        }
        public void onClictButtonConsume()
        {
            _inventory.ShowConsumables();
        }
        public void onClictButtonArmor()
        {
            _inventory.ShowArmor();
        }
        public void onClictButtonWeapon()
        {
            _inventory.ShowWeapon();
        }
    }
}