using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Shared.Dialog
{
    public abstract class Dialog<V,T> : MonoBehaviour where V:DialogArgs where T : DialogResult
    {
        public event Action<T> Closed;
        [SerializeField] private Canvas _canvas;
        public void Open(V args)
        {
            _canvas.enabled = true;
            OnOpen(args);
        }
        protected abstract void OnOpen(V args);
        protected void Close(T Arg)
        {
            Closed?.Invoke(Arg);
            _canvas.enabled = false;
        }
    }
    public class DialogArgs { }
    public class DialogResult { }
}

