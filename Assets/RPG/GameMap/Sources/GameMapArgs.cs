using RPG.Shared;
using RPG.Shared.Scenes;
using RPG.Shared.UserData;

namespace RPG.GameMap
{
    public class GameMapArgs : SceneArgs
    {
        public PlayerSave Save { get; }
        public PrefsJsonProvider PrefsProvider { get; }
        public GameMapArgs(PrefsJsonProvider prefsJsonProvider, PlayerSave save)
        {
            Save = save;
            PrefsProvider = prefsJsonProvider;
        }

    }
}

