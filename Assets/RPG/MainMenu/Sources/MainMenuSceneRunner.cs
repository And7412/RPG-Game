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
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _startButton;
        [SerializeField] private YesNoDialog _yesNoDialog;
        [SerializeField] private string _textYesNoDialog;


        private PlayerSave _save;
        private PrefsJsonProvider _jsonProvider;
        private SceneController _sceneController;

        protected override void Run(MainMenuArgs args)
        {
            Debug.Log("3456");
            _exitButton.onClick.AddListener(OnExitButtonClicked);
            _startButton.onClick.AddListener(OnStartButtonClicked);
            _jsonProvider = args.PrefsProvider;
            _sceneController = SceneController;
            _save = args.Save;
            _yesNoDialog.Closed += OnExit;

        }
        private void OnExitButtonClicked()
        {
            _yesNoDialog.Open(new DialogConfirmArgs(_textYesNoDialog));
        }
        private void OnExit(DialogConfirmResult x)
        {
            if (x.Confirm)
            {
                Application.Quit();
            }
            else
            {
                return;
            }
        }
        private void OnStartButtonClicked()
        {
            _sceneController.LoadGameMap(new GameMapArgs(_jsonProvider, _save));
        }
    }
}

