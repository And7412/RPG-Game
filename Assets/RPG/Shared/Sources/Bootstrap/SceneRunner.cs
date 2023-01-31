using RPG.Shared.Scenes;
using UnityEngine;

namespace RPG.Shared
{
    public abstract class SceneRunner<T> : MonoBehaviour where T: SceneArgs
    {
        protected SceneController SceneController { get; private set; }
        public void DoRun(T args,SceneController sceneController)
        {
            SceneController = sceneController;
            Run(args);
        }
        protected abstract void Run(T args);
    }
}

