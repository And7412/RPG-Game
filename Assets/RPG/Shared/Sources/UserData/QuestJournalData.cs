using System;

namespace RPG.Shared.UserData
{
    [Serializable]
    public class QuestJournalData
    {
        public QuestData[] Quests { get; set; } = new QuestData[0];
    }
    
    [Serializable]
    public class QuestData
    {
        public string Id { get; set; }
        public int Status { get; set; }
    }
}

