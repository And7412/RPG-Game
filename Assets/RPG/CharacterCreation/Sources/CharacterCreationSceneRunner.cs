using RPG.Shared;
using UnityEngine;

namespace RPG.CharacterCreation
{
    public class CharacterCreationSceneRunner : SceneRunner<CharacterCreationArgs>
    {
        [SerializeField] private CharacterCreationQuestionnare _questionnare;
        
        protected override CharacterCreationArgs GetTestArgs()
        {
            return new CharacterCreationArgs();
        }

        protected override async void Run(CharacterCreationArgs args)
        {
            var attributes = await _questionnare.Run();
        }
    }
}