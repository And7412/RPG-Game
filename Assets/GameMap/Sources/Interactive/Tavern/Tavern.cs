using System;
using RPG.Heroes.Tavern;
using RPG.Shared;
using UnityEngine;
using RPG.PlayerSystem;

namespace RPG.GameMap.TavernSystem
{
    public class Tavern : MonoBehaviour
    {
        [SerializeField] private HireMenu _hireMenu;
        [SerializeField] private PointClickHandler _clickHandler;
        [SerializeField] private TavernHero _testHero;
        [SerializeField] private TavernHeroConfig _testConfig;
        [SerializeField] private Canvas _canvas;
        private Player _player;

        public void Initialize(Player player)
        {
            _clickHandler.Clicked += OnClicked;
            _canvas.enabled = false;
            _testHero.Clicked += OnHeroClicked;
            _player = player;

            //не навсегда!
            _testHero.Initialize(_testConfig);
        }

        private void OnHeroClicked(TavernHero hero)
        {
            var args = new HireMenuArgs(hero.Config,_player);
            _hireMenu.Open(args);
        }

        private void OnDestroy()
        {
            _clickHandler.Clicked -= OnClicked;
        }

        private void OnClicked()
        {
            _canvas.enabled = true;
        }
    }
}

