using Core.Patterns.ServiceLocator;
using RPG.GameMap;
using RPG.Shared;
using RPG.Shared.UserData;
using RPG.Shared.UserData.HeroSave;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.MainMenu
{
    public class MainMenuSceneRunner : SceneRunner<MainMenuArgs>
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _exitButton;

        private UserSave _userSave;
        private HeroData _player;

        protected override void Run(MainMenuArgs args)
        {
            _startButton.onClick.AddListener(OnStartButtonClicked);
            var userSave = ServiceLocator.Instance.GetService<UserSaveSystem>();
            _text.text = userSave.CurrentSave.Name;

            _exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        private void OnExitButtonClicked()
        {
            Application.Quit();
        }

        private void OnStartButtonClicked()
        {
            SceneController.LoadGameMap(new GameMapArgs(_userSave));
        }
    }
}

