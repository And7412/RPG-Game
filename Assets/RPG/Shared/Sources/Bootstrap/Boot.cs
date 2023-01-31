using System.Collections;
using System.Collections.Generic;
using RPG.MainMenu;
using RPG.Shared.Scenes;
using UnityEngine;

namespace RPG.Shared
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private SceneController _sceneController;

        private void Awake()
        {
            _sceneController.Initialize();
            //LOAD ALL SAVES
            _sceneController.LoadMainMenu(new MainMenuArgs(_sceneController));
        }
    }
}

