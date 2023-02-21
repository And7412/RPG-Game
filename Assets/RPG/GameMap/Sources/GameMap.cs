using Core.Patterns.ServiceLocator;
using RPG.GameMap.Shop;
using RPG.GameMap.TavernSystem;
using RPG.Metagame.Player;
using RPG.Shared;
using RPG.Shared.Dialog;
using RPG.Shared.UserData;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.GameMap
{
    public class GameMap : SceneRunner<GameMapArgs>
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Button _quit;
        [SerializeField] private Button _save;
        [SerializeField] private Tavern _tavern;
        [SerializeField] private Market _market;

        [SerializeField] private string _textExitDialog;
        [SerializeField] private string _textExitButtonToMainMenu;
        [SerializeField] private string _textExitButton;

        private ExitDialog _exitDialog;
        private Player _player;

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
            var provider = ServiceLocator.Instance.GetService<PrefsJsonProvider>();
            var save = provider.Load<PlayerSave>();
            _exitDialog = new ExitDialog();

            _player = new Player(_playerConfig, save);

            _player.SetMaxHP();
            _tavern.Initialize(_player);
            _market.Initialize(_player);
        }

        private void Save()
        {
            //var PrefProvider = ServiceLocator.Instance.GetService<PrefsJsonProvider>();
        }
        private void Exit()
        {
            _exitDialog.Open(new ExitDialogArgs(_textExitDialog,_textExitButton,_textExitButtonToMainMenu));
        }
    }
}

