using System;
using UnityEngine;
namespace RPG.Shared.Dialog
{
    public class EnterKeyObserver : MonoBehaviour
    {
        public event Action EnterEvent;
        private readonly KeyCode _key = KeyCode.KeypadEnter;

        private void Update()
        {
            if (Input.GetKeyDown(_key))
            {
                EnterEvent?.Invoke();
            }
        }
    }
}
