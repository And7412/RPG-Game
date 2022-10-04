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
        public event Action<InventoryItem> Clicked;
        private InventoryItem _item;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _text;

        public void SetConfig(InventoryItem item)
        {
            _item = item;
            _image.sprite= item.Config.Sprite;
            _text.text = item.Amount.ToString();
        }
    }
}

