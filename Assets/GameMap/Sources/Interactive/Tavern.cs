using System;
using RPG.Shared;
using UnityEngine;

namespace RPG.GameMap
{
    public class Tavern : MonoBehaviour
    {
        [SerializeField] private PointClickHandler _clickHandler;

        private void Awake()
        {
            _clickHandler.Clicked += OnClicked;
        }

        private void OnDestroy()
        {
            _clickHandler.Clicked -= OnClicked;
        }

        private void OnClicked()
        {
            Debug.Log("You entered tavern");
        }
    }
}

