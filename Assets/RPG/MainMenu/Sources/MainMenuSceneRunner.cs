using RPG.GameMap;
using RPG.Shared;

namespace RPG.MainMenu
{
    public class MainMenuSceneRunner : SceneRunner<MainMenuArgs>
    {
        public override async void Run(MainMenuArgs args)
        {
            //WAIT FOR LOAD BUTTON PRESS

            args.SceneController.LoadGameMap(new GameMapArgs(args.SceneController));
        }
    }
}

