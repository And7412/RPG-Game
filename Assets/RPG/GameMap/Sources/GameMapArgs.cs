using RPG.Shared;
using RPG.Shared.Scenes;
using RPG.Shared.UserData;

namespace RPG.GameMap
{
    public class GameMapArgs : SceneArgs
    {
        public UserSave Save;
        public GameMapArgs(UserSave save)
        {
            Save = save;
        }

    }
}

