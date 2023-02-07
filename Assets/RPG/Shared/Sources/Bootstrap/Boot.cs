using RPG.MainMenu;
using RPG.Shared.Scenes;
using UnityEngine;

namespace RPG.Shared
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private SceneController _sceneController;
        [SerializeField] private PrefsJsonProvider _prefsJsonProvider;
        [SerializeField] private LoadScreen _loadScreen;


        private void Awake()
        {
            DontDestroyOnLoad(_loadScreen.gameObject);
            _sceneController.Initialize();
            _prefsJsonProvider.Initializ();
            //LOAD ALL SAVES
            _sceneController.LoadMainMenu(new MainMenuArgs());//TODO
        }
    }
}

