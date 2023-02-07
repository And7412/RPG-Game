using RPG.MainMenu;
using RPG.Shared.Scenes;
using UnityEngine;

namespace RPG.Shared
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private SceneController _sceneController;
        [SerializeField] private PrefsJsonProvider _prefsJsonProvider;

        private void Awake()
        {
            _sceneController.Initialize();
            _prefsJsonProvider.Initializ();
            //LOAD ALL SAVES
            _sceneController.LoadMainMenu(new MainMenuArgs(_prefsJsonProvider,new UserData.PlayerSave()));//TODO
        }
    }
}

