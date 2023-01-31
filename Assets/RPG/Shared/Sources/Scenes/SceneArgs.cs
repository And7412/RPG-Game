using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Shared.Scenes
{
    public class SceneArgs
    {
        public SceneController SceneController { get; }

        public SceneArgs(SceneController sceneController)
        {
            SceneController = sceneController;
        }
    }
}

