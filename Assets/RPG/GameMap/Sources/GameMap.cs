using RPG.Metagame.Player;
using UnityEngine;
using RPG.GameMap.Shop;
using RPG.GameMap.TavernSystem;
using RPG.Shared;

namespace RPG.GameMap
{
    public class GameMap : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Tavern _tavern;
        [SerializeField] private Market _market;

        private void Awake()
        {
            var userSave = PrefsJsonProvider.Load<UserSave>();
            var player = new Player(_playerConfig, userSave);

            //player.SetMaxHP();
            _tavern.Initialize(player);
            _market.Initialize(player);

            
        }
    }
}

