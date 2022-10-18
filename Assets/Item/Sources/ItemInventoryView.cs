using Core.Patterns.Pool;
using System;
using Core.Patterns.Factory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.InventorySystem
{
    public class ItemInventoryView : MonoBehaviour, IPoolable
    {
        public bool Active { get; private set; }

        public event Action<InventoryCell> Clicked;
        private InventoryCell _cell;

        [SerializeField] private Image _iconImage;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Clicked?.Invoke(_cell);
        }

        public void SetActive(bool value)
        {
            Active = value;
        }

        public void SetCell(InventoryCell args)
        {
            _cell = args;
            _iconImage.sprite = args.Config.Sprite;
            _text.text = args.Amount.ToString();
        }
    }
}

