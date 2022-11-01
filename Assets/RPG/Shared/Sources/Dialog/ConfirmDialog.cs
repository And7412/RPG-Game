using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace RPG.Shared.Dialog
{
    public class ConfirmDialog :Dialog<DialogConfirmArgs, DialogResult>
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Button _button;

        private void Awake()
        {
            _canvas.enabled = false;
            _button.onClick.AddListener(Confirm);
        }

        protected override void OnOpen(DialogConfirmArgs args)
        {
            _text.text = args.Text;
            _canvas.enabled = true;
        }
        public void Confirm()
        {
            Close(new DialogResult());
            
        }
    }
}