using RPG.GameMap;
using RPG.MainMenu;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.Shared.Scenes
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private string _mainMenu;
        [SerializeField] private string _gameMap;
        [SerializeField] private LoadScreen _loadScreen;

        public void Initialize()
        {
            DontDestroyOnLoad(gameObject);
        }

        public async void LoadMainMenu(MainMenuArgs args)
        {
            await LoadScene(args, _mainMenu);
        }

        public async void LoadGameMap(GameMapArgs args)
        {
            await LoadScene(args, _gameMap);
        }

        private async Task LoadScene<T>(T args, string name) where T: SceneArgs
        {
            var operation = SceneManager.LoadSceneAsync(name);
            _loadScreen.SetVisible(true);

            while (!operation.isDone)
            {
                _loadScreen.UpdateProgressbar(operation.progress);
                await Task.Yield();
            }

            await Task.Delay(1000);
            var bootstrap = FindObjectOfType<SceneRunner<T>>();
            bootstrap.DoRun(args, this);
            _loadScreen.SetVisible(false);
        }
    }
}

