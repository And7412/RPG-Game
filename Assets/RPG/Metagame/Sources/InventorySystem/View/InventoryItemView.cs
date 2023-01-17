using Core.Patterns.Pool;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Metagame.InventorySystem.View
{
    public class InventoryItemView : MonoBehaviour, IPoolable
    {
        public bool Active { get; private set; }

        public event Action<IInventoryCell> Clicked;
        private IInventoryCell _cell;

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
            gameObject.SetActive(value);
        }

        public void SetCell(IInventoryCell args)
        {
            _cell = args;
            _iconImage.sprite = args.Config.Sprite;
            _text.text = args.Amount.ToString();
        }
    }
}

