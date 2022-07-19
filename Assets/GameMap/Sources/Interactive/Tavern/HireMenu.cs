using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using RPG.Heroes.Tavern;
using RPG.PlayerSystem;
using RPG.Shared.Dialog;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.GameMap.Tavern
{
    public class HireMenu : MonoBehaviour, IDialog<HireMenuArgs, HireMenuResult>
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Image _heroIconImage;
        [SerializeField] private TextMeshProUGUI _descriptionText;

        private TavernHeroConfig _current;

        public event Action<HireMenuResult> Closed;

        public void Open(HireMenuArgs args)
        {
            _current = args.HeroConfig;
            ShowHero(_current);
            ShowMenu(true);
        }

        public void Close()
        {
            var result = new HireMenuResult(_current, false);
            Closed?.Invoke(result);
            ShowMenu(false);
        }

        public void ShowMenu(bool value) => _canvas.enabled = value;

        private void Hire()
        {
            var result = new HireMenuResult(_current, true);
            Closed?.Invoke(result);
            ShowMenu(false);
        }

        private void Awake()
        {
            _canvas.enabled = false;
        }

        private void ShowHero(TavernHeroConfig config)
        {
            _current = config;
            _heroIconImage.sprite = config.Icon;
            _descriptionText.text = config.Description;
        }
    }

    public class HireMenuArgs : DialogArgs
    {
        public Player Player { get; }
        public TavernHeroConfig HeroConfig { get; }

        public HireMenuArgs(TavernHeroConfig heroConfig)
        {
            HeroConfig = heroConfig;
        }
    }

    public class HireMenuResult : DialogResult
    {
        public bool Hired { get; }
        private TavernHeroConfig HeroConfig { get; }

        public HireMenuResult(TavernHeroConfig heroConfig, bool hired)
        {
            HeroConfig = heroConfig;
            Hired = hired;
        }
    }

}

