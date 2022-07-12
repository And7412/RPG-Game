using System;
using UnityEngine;

namespace RPG.Shared.Dialog
{
    public interface IDialog<T,V> where T: DialogArgs where V: DialogResult
    {
        event Action<V> Closed;
        void Open(T args);
    }

    public class DialogArgs { }
    public class DialogResult { }
}
