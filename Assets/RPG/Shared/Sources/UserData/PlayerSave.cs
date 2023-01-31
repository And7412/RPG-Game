using System;
using RPG.Metagame;

namespace RPG.Shared.UserData
{
    [Serializable]
    public class PlayerSave
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Xp { get; set; }
        public int Money { get; set; }
        public InventoryItemCount[] InventoryItems { get; set; }
        public Quest[] Quests { get; set; }
        public int Difficulty { get; set; } = 1;
        public int Health { get; set; }
        public int Stamina { get; set; }

        [Serializable]
        public class Quest
        {
            public string Id { get; set; }
            public string Status { get; set; }
        }

        public Difficulty DifficultyEnum => (Difficulty) Difficulty;
    }
}