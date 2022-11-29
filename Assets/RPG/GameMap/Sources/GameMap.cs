using RPG.Metagame.Player;
using UnityEngine;
using RPG.GameMap.Shop;
using RPG.GameMap.TavernSystem;

namespace RPG.GameMap
{
    public class GameMap : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Tavern _tavern;
        [SerializeField] private Market _market;

        private void Awake()
        {

            var player = new Player(_playerConfig);
            //player.SetMaxHP();
            _tavern.Initialize(player);
            _market.Initialize(player);

            
        }
    }
}

