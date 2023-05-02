using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.GameMap.MarketSystem
{ 
    public class ShopIcon : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Shop _shop;

        public Shop Shop => _shop;
        public event Action<Shop> ShopOpened;

        private void Awake()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnClicked()
        {
            ShopOpened?.Invoke(_shop);
            _shop.Show();
        }
        
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClicked);
        }
    }
}
