using System;
using RPG.Metagame;
using RPG.Shared.UserData.HeroSave;

namespace RPG.Shared.UserData
{
    [Serializable]
    public class UserSave
    {
        public string Name = string.Empty;
        public long SaveDate = 0;
        public HeroData PlayerHeroData = new HeroData();
        public QuestJournalData QuestJournalData = new QuestJournalData();
        public VendorsData VendorsData = new VendorsData();
        public int Difficulty { get; set; } = 1;
        
        public Difficulty DifficultyEnum => (Difficulty) Difficulty;
    }
}
