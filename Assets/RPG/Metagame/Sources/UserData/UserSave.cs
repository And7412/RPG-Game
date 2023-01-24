using System;
using RPG.Metagame;

namespace RPG.Shared
{
    [Serializable]
    public class UserSave
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

        [Serializable]
        public class InventoryItemCount
        {
            public string Id { get; set; }
            public int Count { get; set; }
        }
    }
}