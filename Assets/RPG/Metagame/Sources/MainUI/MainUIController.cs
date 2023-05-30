using System;
using RPG.Metagame.Heroes.Player;
using UnityEngine;

namespace RPG.Metagame.MainUI
{
    public class MainUIController : MonoBehaviour
    {
        [SerializeField] private PlayerPanel _playerPanel;
        [SerializeField] private InformationPanel _informationPanel;


        private void Awake()
        {
            _playerPanel.ToolsPressed += OnToolsPressed;
            _playerPanel.StatsPressed += OnStatsPressed;
        }
        
        private void OnDestroy()
        {
            _playerPanel.ToolsPressed -= OnToolsPressed;
            _playerPanel.StatsPressed -= OnStatsPressed;
        }

        public void Initialize(IPlayer player)
        {
            _informationPanel.Initialize(player);
        }

        private void OnStatsPressed()
        {
            if (!_informationPanel.Opened)
                _informationPanel.Open();
            else
                _informationPanel.Hide();
            
        }

        private void OnToolsPressed()
        {
            throw new NotImplementedException();
        }
    }
}

