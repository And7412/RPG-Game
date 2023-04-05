using RPG.Shared;
using UnityEngine;
using RPG.Metagame.Player;
using RPG.Shared.UserData;
using System.Threading.Tasks;

namespace RPG.CharacterCreation
{
    public class CharacterCreationSceneRunner : SceneRunner<CharacterCreationArgs>
    {
        [SerializeField] private CharacterCreationQuestionnare _questionnare;
        [SerializeField] private Shared.SystemData.QuestDataBase _questDataBase;
        [SerializeField] private CreateNamePlayerDialog _createNameDialog;

        private PlayerSave _playerSave = new PlayerSave();
        private PlayerAttributes _playerAttributes = new PlayerAttributes(0,0,0,0,0,0,0);
        private PlayerLevel _playerLevel = new PlayerLevel(0, 1, 100, Metagame.Difficulty.Medium);

        public PlayerAttributes PlayerAttributes => _playerAttributes;

        public UserSave _userSave;

        protected override CharacterCreationArgs GetTestArgs()
        {
            return new CharacterCreationArgs();
        }

        protected override async void Run(CharacterCreationArgs args)
        {
            var name = await _createNameDialog.Run(new DialogCreateNamePlayerArg());
            var attributes = await _questionnare.Run();
            foreach(AttributeMock mock in attributes)
            {
                _playerAttributes.AddSkill(mock.Name, mock.Value);
            }
            
            
            _userSave.Name=name.Name;
            _userSave.PlayerSave = SetPlayerSave(name.Name);
        }
        private PlayerSave SetPlayerSave(string name)
        {
            PlayerSave save;
            save = new PlayerSave();
            save.Name = name;
            save.Level = 1;
            save.Xp = 0;
            save.Money = 100;
            save.Difficulty = (int) Metagame.Difficulty.Medium;
            save.Quests = new PlayerSave.Quest[_questDataBase.Quests.Capacity];
            save.Stamina = _playerLevel.GetMaxHealth(100);
            return save;
        }
    }
}