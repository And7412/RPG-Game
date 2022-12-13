using System.Collections;
using System.Collections.Generic;
using RPG.Shared;
using UnityEngine;
namespace RPG.GameMap.Shop
{ 
    public class ShopIcon : MonoBehaviour
    {
        [SerializeField] private PointClickHandler _clickHandler;
        [SerializeField] private Shop _shop;

        private void Awake()
        {
            _clickHandler.Clicked += OnClicked;
            _shop.SetActive(false);
        }

        private void OnClicked()
        {
            _shop.SetActive(true);
        }
    }
}
