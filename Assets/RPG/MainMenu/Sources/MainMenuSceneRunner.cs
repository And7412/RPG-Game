using Core.Saves;
using RPG.GameMap;
using RPG.Shared;
using RPG.Shared.Dialog;
using RPG.Shared.Scenes;
using RPG.Shared.UserData;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.MainMenu
{
    public class MainMenuSceneRunner : SceneRunner<MainMenuArgs>
    {
        [SerializeField] private Button _startButton;

        private PlayerSave _save;
        //private PrefsJsonProvider _jsonProvider;

        protected override MainMenuArgs GetTestArgs()
        {
            return new MainMenuArgs();
        }

        protected override void Run(MainMenuArgs args)
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
            //_jsonProvider = args.PrefsProvider;
            //_save = args.Save;
        }


        private void OnStartButtonClicked()
        {
            SceneController.LoadGameMap(new GameMapArgs());
        }
    }
}

