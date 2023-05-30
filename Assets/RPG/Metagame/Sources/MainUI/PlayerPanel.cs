using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Metagame.MainUI
{
    public class PlayerPanel : MonoBehaviour
    {
        [SerializeField] private Button _statsButton;
        [SerializeField] private Button _toolsButton;

        public event Action ToolsPressed;
        public event Action StatsPressed;

        private void Awake()
        {
            _statsButton.onClick.AddListener(OnStatsClicked);
            _toolsButton.onClick.AddListener(OnToolsClicked);
        }

        private void OnStatsClicked()
        {
            StatsPressed?.Invoke();
        }
        
        private void OnToolsClicked()
        {
            ToolsPressed?.Invoke();
        }
    }
}

