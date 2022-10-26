using RPG.Metagame.Player;
using UnityEngine;

namespace RPG.GameMap
{
    public class GameMap : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private TavernSystem.Tavern _tavern;

        private void Awake()
        {

            var player = new Player(_playerConfig);
            //player.SetMaxHP();
            _tavern.Initialize(player);

            
        }
    }
}

