using Core.Patterns.ServiceLocator;
using Core.Saves;
using RPG.MainMenu;
using RPG.Shared.Scenes;
using RPG.Shared.UserData;
using UnityEngine;

namespace RPG.Shared
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private SceneController _sceneController;
        [SerializeField] private LoadScreen _loadScreen;

        private void Awake()
        {
            RegisterServices();
            DontDestroyOnLoad(_loadScreen.gameObject);

            _sceneController.Initialize();
            _sceneController.LoadMainMenu(new MainMenuArgs());
        }

        private void RegisterServices()
        {
            var locator = ServiceLocator.Initialize();
            var userStorage = new UserStorage();
            var userSaveSystem = new UserSaveSystem(userStorage);

            locator.Register(userSaveSystem);
        }

        private void LoadNextScene()
        {

        }
    }
}

