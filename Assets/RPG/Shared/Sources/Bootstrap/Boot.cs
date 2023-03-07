using Core.Patterns.ServiceLocator;
using Core.Saves;
using RPG.MainMenu;
using RPG.Shared.Scenes;
using UnityEngine;

namespace RPG.Shared
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private SceneController _sceneController;
        [SerializeField] private UserS _prefsJsonProvider;
        [SerializeField] private LoadScreen _loadScreen;


        private void Awake()
        {
            DontDestroyOnLoad(_loadScreen.gameObject);
            _sceneController.Initialize();
            _prefsJsonProvider.Initializ();

            var locator = ServiceLocator.Initialize();
            locator.Register(_prefsJsonProvider);
            
            _sceneController.LoadMainMenu(new MainMenuArgs());
        }
    }
}

