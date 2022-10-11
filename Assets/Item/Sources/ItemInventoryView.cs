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
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _text;

        public void SetActive(bool value)
        {
            Active = value;
        }

        public void SetCell(InventoryCell args)
        {
            _cell = args;
            _image.sprite = args.Config.Sprite;
            _text.text = args.Amount.ToString();
        }
    }
}

