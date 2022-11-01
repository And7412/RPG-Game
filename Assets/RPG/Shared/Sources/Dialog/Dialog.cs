using System;
using UnityEngine;

namespace RPG.Shared.Dialog
{
    public abstract class Dialog<V,T> : MonoBehaviour where V:DialogArgs where T : DialogResult
    {
        [SerializeField] private Canvas _canvas;

        public event Action<T> Closed;

        private void Awake()
        {
            _canvas.enabled = false;
        }

        public void Open(V args)
        {
            _canvas.enabled = true;
            OnOpen(args);
        }

        protected virtual void OnOpen(V args) { }

        protected void Close(T Arg)
        {
            Closed?.Invoke(Arg);
            _canvas.enabled = false;
        }

        protected virtual void OnClose(T args) { }
    }

    public class DialogArgs { }
    public class DialogResult { }
}

