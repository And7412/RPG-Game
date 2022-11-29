using System;
using System.Collections;
using System.Collections.Generic;
using RPG.GameMap.TavernSystem;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.GameMap.TavernSystem
{
    public class TavernHero : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public event Action<TavernHero> Clicked; 
        public TavernHeroConfig Config { get; private set; }

        private void Awake()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Clicked?.Invoke(this);
        }

        public void Initialize(TavernHeroConfig config)
        {
            Config = config;
        }

        public void SetVisible(bool value)
        {
            gameObject.SetActive(value);
        }

    }
}

