using Core.Patterns.ServiceLocator;
using Core.Saves;
using RPG.CharacterCreation;
using RPG.MainMenu;
using RPG.Shared.Dialog;
using RPG.Shared.Scenes;
using RPG.Shared.UserData;
using UnityEngine;

namespace RPG.Shared
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private SceneController _sceneController;
        [SerializeField] private LoadScreen _loadScreen;
        [SerializeField] private DialogsService _dialogService;

        private void Awake()
        {
            SetDontDestroy();
            _sceneController.Initialize();
            
            var locator = ServiceLocator.Initialize();
            var userStorage = new UserStorage();
            var userSaveSystem = new UserSaveSystem(userStorage);

            locator.Register(userSaveSystem);
            locator.Register(_dialogService);
            
            LoadNextScene(userSaveSystem);
        }

        private void SetDontDestroy()
        {
            DontDestroyOnLoad(_loadScreen.gameObject);
            DontDestroyOnLoad(_dialogService.gameObject);
        }

        private void LoadNextScene(UserSaveSystem userSave)
        {
            var saves = userSave.DoesSavesExist();
            if (saves)
            {
                _sceneController.LoadMainMenu(new MainMenuArgs());
            }
            else
            {
                _sceneController.LoadCharacterCreation(new CharacterCreationArgs());
            }
        }
    }
}

