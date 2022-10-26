using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPG.Shared
{
    public class PointClickHandler : MonoBehaviour, IPointerClickHandler
    {
        public event Action Clicked;

        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke();
        }
    }
}

