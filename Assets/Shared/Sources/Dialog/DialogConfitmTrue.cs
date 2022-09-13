using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace RPG.Shared.Dialog
{
    public class DialogConfitmTrue : MonoBehaviour, IDialog<DialogConfirmArgs, DialogResult>
    {
        public event Action<DialogResult> Closed;

        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Canvas _canvas;

        private void Awake()
        {
            _canvas.enabled = false;
        }

        public void Open(DialogConfirmArgs args)
        {
            _text.text = args.Text;
            _canvas.enabled = true;
        }
        public void Confirm()
        {
            
            _canvas.enabled = false;
            Closed?.Invoke(new DialogResult());
        }
    }
}