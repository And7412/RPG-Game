using RPG.GameMap.Shop;
using RPG.GameMap.TavernSystem;
using RPG.Metagame.Player;
using RPG.Shared;
using RPG.Shared.UserData;
using UnityEngine;

namespace RPG.GameMap
{
    public class GameMap : SceneRunner<GameMapArgs>
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Tavern _tavern;
        [SerializeField] private Market _market;

        protected override GameMapArgs GetTestArgs()
        {
            return new GameMapArgs();
        }

        protected override void Run(GameMapArgs args)
        {
            Initialize(args);
        }

        private void Initialize(GameMapArgs args)
        {
            ////var player = new Player(_playerConfig, args.Save);

            ////player.SetMaxHP();
            //_tavern.Initialize(player);
            //_market.Initialize(player);
        }
    }
}

