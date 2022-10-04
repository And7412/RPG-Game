using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Item;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RPG.InventorySystem
{
    public class ItemInventoryView : MonoBehaviour
    {
        public event Action<InventoryCell> Clicked;
        private InventoryCell _cell;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _text;

        public void SetCell(InventoryCell cell)
        {
            _cell = cell;
            _image.sprite= cell.Config.Sprite;
            _text.text = cell.Amount.ToString();
        }
    }
}

