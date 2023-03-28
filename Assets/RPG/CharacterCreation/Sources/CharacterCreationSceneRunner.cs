using RPG.Shared;
using UnityEngine;

namespace RPG.CharacterCreation
{
    public class CharacterCreationSceneRunner : SceneRunner<CharacterCreationArgs>
    {
        [SerializeField] private CharacterCreationQuestionnare _questionnare;

        [SerializeField] private CreateNamePlayerDialog _createNameDialog;

        protected override CharacterCreationArgs GetTestArgs()
        {
            return new CharacterCreationArgs();
        }

        protected override async void Run(CharacterCreationArgs args)
        {
            var name = _createNameDialog.Run(new DialogCreateNamePlayerArg());
            var attributes = await _questionnare.Run();
        }
    }
}