using System;

namespace RPG.Shared
{
    [Serializable]
    public class UserSave
    {
        public string Name { get; set; }
        public LevelClass Level { get; set; }
        public int Money { get; set; }
        public string[] InventoryItemsId { get; set; }
        public Quest[] Quests { get; set; }

        [Serializable]
        public class Quest
        {
            public string Id { get; set; }
            public string Status { get; set; }
        }

        [Serializable]
        public class LevelClass
        {
            public int Level { get; set; }
            public int Xp { get; set; }
            public int Ratio { get; set; }
        }
    }
}

