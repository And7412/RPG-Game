using RPG.Metagame.Heroes.Player;
using UnityEngine;

namespace RPG.Metagame.MainUI
{
    public class StatPanel : MonoBehaviour
    {
        [SerializeField] private StatView _statHelse;
        [SerializeField] private StatView _statMana;
        [SerializeField] private StatView _stat3;
        [SerializeField] private StatView _stat4;
        [SerializeField] private StatView _stat5;
        [SerializeField] private StatView _stat6;
        [SerializeField] private StatView _stat7;
        [SerializeField] private StatView _stat8;
        [SerializeField] private StatView _stat9;
        [SerializeField] private StatView _stat10;
        [SerializeField] private StatView _stat11;
        [SerializeField] private StatView _stat12;

        private IPlayer _player;

        public void Initialize(IPlayer player)
        {
            _player = player;
        }

        public void Refresh()
        {
            _statHelse.SetValue(_player.Health.Value);
        }
    }
}

