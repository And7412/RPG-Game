using System.Collections;
using System.Collections.Generic;
using RPG.Metagame.Player;
using UnityEngine;
using RPG.Shared;

namespace RPG.GameMap.Shop
{
    public class Market : MonoBehaviour
    {
        [SerializeField] private Shop[] _shops;
        [SerializeField] private PointClickHandler _mapButton;
        [SerializeField] private Canvas _canvas;
        private void Awake()
        {
            _canvas.enabled = false;
            
        }
        public void Initialize(IPlayerTrade player)
        {
            _mapButton.Clicked += OnClicked;
            foreach (var shop in _shops)
            {
                shop.Initialize(player);
            }
        }
        private void OnClicked()
        {
            _canvas.enabled = true;
        }
    }
}

