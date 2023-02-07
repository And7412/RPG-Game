using RPG.Shared;
using RPG.Shared.Scenes;
using RPG.Shared.UserData;

namespace RPG.MainMenu
{
    public class MainMenuArgs : SceneArgs
    {
        public PrefsJsonProvider PrefsProvider { get; }
        public PlayerSave Save { get; }
        public MainMenuArgs(PrefsJsonProvider prefsJsonProvider,PlayerSave save)
        {
            Save = save;
            PrefsProvider = prefsJsonProvider;
        }
    }
}

