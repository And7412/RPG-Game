using RPG.Shared.Scenes;
using UnityEngine;

namespace RPG.Shared
{
    public abstract class SceneRunner<T> : MonoBehaviour where T: SceneArgs
    {
        public abstract void Run(T args);
    }
}

