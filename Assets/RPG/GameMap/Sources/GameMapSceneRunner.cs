using Core.Patterns.ServiceLocator;
using RPG.GameMap.MarketSystem;
using RPG.GameMap.TavernSystem;
using RPG.Metagame.Heroes.Player;
using RPG.Shared;
using RPG.Shared.Dialog;
using RPG.Shared.UserData;
using UnityEngine;

namespace RPG.GameMap
{
    public class GameMapSceneRunner : SceneRunner<GameMapArgs>
    {
        [SerializeField] private GameMapDataSaver _dataSaver;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Tavern _tavern;
        [SerializeField] private MarketInstance _market;

        [SerializeField] private string _textExitDialog;
        [SerializeField] private string _textExitButtonToMainMenu;
        [SerializeField] private string _textExitButton;

        private ExitDialog _exitDialog;
        private Player _player;

        protected override void Run(GameMapArgs args)
        {
            Initialize(args);
        }

        private void Initialize(GameMapArgs args)
        {
            var saveSystem = ServiceLocator.Instance.GetService<UserSaveSystem>();


            _exitDialog = new ExitDialog();

            _player = new Player(_playerConfig, args.Save.PlayerHeroData, args.Save.DifficultyEnum, args.Save.Name);

            _player.SetMaxHP();
            _tavern.Initialize(_player);
            _market.Initialize(_player);

            _dataSaver.InitializeBuffer(_player, _market);
        }

        private void Save()
        {
            //var PrefProvider = ServiceLocator.Instance.GetService<PrefsJsonProvider>();
        }
        private void Exit()
        {
           // _exitDialog.Open(new ExitDialogArgs());
        }
    }
}

