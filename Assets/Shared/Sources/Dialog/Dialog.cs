using System;
using UnityEngine;

namespace RPG.Shared.Dialog
{
    public abstract class Dialog<T,V> where T: DialogArgs where V: DialogResult
    {
        public event Action<V> Closed;
        protected V Result;

        public abstract void Open(T args);
        protected abstract void OnClose();

        protected void Close()
        {
            Closed?.Invoke(Result);
            OnClose();
        }
    }

    public class DialogArgs { }
    public class DialogResult { }
}
