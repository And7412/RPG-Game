using System;

namespace RPG.Shared
{
    [Serializable]
    public class UserSave
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string[] Inventory { get; set; }
        public Quest[] Quests { get; set; }

        [Serializable]
        public class Quest
        {
            public string Id { get; set; }
            public string Status { get; set; }
        }
    }
}

