using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Shared
{
    public class LoadScreen : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Canvas _canvas;

        public void SetVisible(bool value)
        {
            _canvas.enabled = value;
        }

        public void UpdateProgressbar(float progress)
        {
            _slider.value = progress;
        }
    }
}

