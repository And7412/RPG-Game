using RPG.Shared;
using RPG.Shared.Scenes;

namespace RPG.MainMenu
{
    public class MainMenuArgs : SceneArgs
    {
        public PrefsJsonProvider PrefsProvider { get; }
        public MainMenuArgs(PrefsJsonProvider prefsJsonProvider)
        {
            PrefsProvider = prefsJsonProvider;
        }
    }
}

