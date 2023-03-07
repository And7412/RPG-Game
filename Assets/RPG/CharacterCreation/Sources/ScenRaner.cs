using RPG.Shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.CharacterCreation
{
    public class CharacterCreationSceneRunner : SceneRunner<CharacterCreationArgs>
    {
        protected override CharacterCreationArgs GetTestArgs()
        {
            return new CharacterCreationArgs();
        }

        protected override void Run(CharacterCreationArgs args)
        {
            
        }
    }
}