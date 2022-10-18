using System.Collections;
using System.Collections.Generic;
using RPG.Shared;
using UnityEngine;
namespace RPG.GameMap.Shop
{ 
    public class ShopIcon : MonoBehaviour
    {
        [SerializeField] private PointClickHandler _clickHandler;
        [SerializeField] private Canvas _canvas;

        private void Awake()
        {
            _clickHandler.Clicked += OnClicked;
            _canvas.enabled = false;
        }

        private void OnClicked()
        {
            _canvas.enabled = true;
        }
    }
}
