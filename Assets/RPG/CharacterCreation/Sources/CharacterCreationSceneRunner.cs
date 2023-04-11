using RPG.Metagame;
using RPG.Metagame.Player;
using RPG.Shared;
using RPG.Shared.UserData;
using RPG.Shared.UserData.HeroSave;
using UnityEngine;

namespace RPG.CharacterCreation
{
    public class CharacterCreationSceneRunner : SceneRunner<CharacterCreationArgs>
    {
        [SerializeField] private CharacterCreationQuestionnare _questionnare;
        [SerializeField] private CreateNamePlayerDialog _createNameDialog;

        public UserSave _userSave;

        protected override CharacterCreationArgs GetTestArgs()
        {
            return new CharacterCreationArgs();
        }

        protected override async void Run(CharacterCreationArgs args)
        {
            var name = await _createNameDialog.Run(new DialogCreateNamePlayerArg());
            var attributes = await _questionnare.Run();
            var playerAttributesModel = new PlayerAttributes(0,0,0,0,0,0,0);
            
            foreach(AttributeMock mock in attributes)
            {
                playerAttributesModel.AddSkill(mock.Name, mock.Value);
            }
            
            //TODO choose difficulty window
            var difficulty = Difficulty.Medium;
            
            //TODO where to find user save for overwrite?
            //TODO in user save system add save method with date time saving
            var userSave = CreateUserSave(name.Name, playerAttributesModel, difficulty);
        }
        
        private UserSave CreateUserSave(string name, PlayerAttributes attributesModel, Difficulty difficulty)
        {
            var save = new UserSave();

            save.Name = name;
            save.Difficulty = (int) difficulty;
            save.PlayerHeroData = CreatePlayer(attributesModel);

            return save;
        }

        private HeroData CreatePlayer(PlayerAttributes attributesModel)
        {
            var attributesData = new HeroAttributesData()
            {
                Strength = attributesModel.GetPoints(AttributeName.Strength),
                Agility = attributesModel.GetPoints(AttributeName.Agility),
                Diligence = attributesModel.GetPoints(AttributeName.Diligence),
                Endurance = attributesModel.GetPoints(AttributeName.Endurance),
                Genius = attributesModel.GetPoints(AttributeName.Genius),
                Intelligence = attributesModel.GetPoints(AttributeName.Intelligence),
                Speed = attributesModel.GetPoints(AttributeName.Speed)
            };
            var heroLevelData = new HeroLevelData()
            {
                Level = 1,
                Xp = 0
            };

            var inventoryData = new InventoryData()
            {
                InventoryItems = new InventoryItemCountData[0],
                Money = 100
            };

            var heroData = new HeroData()
            {
                LevelData = heroLevelData,
                Attributes = attributesData,
                CurrentHealthPercent = 1f,
                CurrentStaminaPercent = 1f,
                InventoryData = inventoryData
            };

            return heroData;
        }
    }
}