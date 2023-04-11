using RPG.GameMap;
using RPG.Shared;
using RPG.Shared.UserData.HeroSave;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.MainMenu
{
    public class MainMenuSceneRunner : SceneRunner<MainMenuArgs>
    {
        [SerializeField] private Button _startButton;

        private HeroData _player;
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

